using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.IO;

namespace DataCodeGenerator.UI
{
    public partial class ClassGenerator : DataCodeGenerator.UI.GeneratorBase
    {
        private ClassGenerator()
        {
            InitializeComponent();
        }

        private static ClassGenerator _Instance;
        public static ClassGenerator GetInstance(string Database, List<string> Tables)
        {
            if (_Instance == null)
                _Instance = new ClassGenerator();
            if (_Instance.IsDisposed)
                _Instance = new ClassGenerator();
            _Instance.Database = Database;
            _Instance.Tables = Tables;
            return _Instance;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btn_ok))
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
                return;
            }
            //if (active_project == null)
            //{
            //    MessageBox.Show("پروژه فعال پیدا نشد");
            //    return;
            //}
            txt_namespace.Text = txt_namespace.Text.Trim();
            //txt_filename.Text = txt_filename.Text.Trim();
            //if (txt_filename.Text == "")
            //{
            //    string errorText = "نام فایل را وارد کنید";
            //    MessageBox.Show(this, errorText);
            //    txt_filename.Focus();
            //    return;
            //}
            CodeCompileUnit unit = new CodeCompileUnit();
            unit.ReferencedAssemblies.Add("System.dll");
            CodeNamespace name_space = null;
            if (txt_namespace.Text != "")
            {
                name_space = new CodeNamespace(txt_namespace.Text);
                unit.Namespaces.Add(name_space);
                name_space.Imports.Add(new CodeNamespaceImport("System"));
                name_space.Imports.Add(new CodeNamespaceImport("System.Data"));
                name_space.Imports.Add(new CodeNamespaceImport("System.Data.SqlClient"));
            }
            List<CodeTypeDeclaration> class_list = new List<CodeTypeDeclaration>();

            foreach (string original_table_name in this.Tables)
            {
                string fixed_table_name = FixName(original_table_name, false, checkBox_to_upper.Checked, chkDeleteS.Checked);
                string fixed_table_name_withoutAt = RemoveAtSign(fixed_table_name);
                string table_id = GetTableID(this.Database, original_table_name);
                if (table_id == null)
                {
                    MessageBox.Show("خطا در دریافت اطلاعات جدول " + original_table_name);
                    return;
                }
                DataTable fields = GetFields(this.Database, table_id);
                if (fields == null)
                {
                    MessageBox.Show("خطا در دریافت اطلاعات جدول " + original_table_name);
                    return;
                }
                //----------------------
                CodeTypeDeclaration table_class = new CodeTypeDeclaration(fixed_table_name);
                if (checkBox_use_comment.Checked)
                {
                    CodeCommentStatement table_comment = new CodeCommentStatement("--------------------------------------------");
                    table_class.Comments.Add(table_comment);
                }

                table_class.IsClass = true;
                table_class.IsPartial = checkBox_partial.Checked;
                if (name_space != null)
                    name_space.Types.Add(table_class);
                class_list.Add(table_class);
                //----------------------
                bool tableHaveIdentityColumn = false;
                foreach (DataRow r in fields.Rows)
                {
                    if (Column_Is_Identity(this.Database, table_id, r["name"].ToString()))
                    {
                        tableHaveIdentityColumn = true;
                        break;
                    }
                }
                if (tableHaveIdentityColumn)
                {
                    if (checkBoxAddIdentity.Checked)
                    {
                        System.CodeDom.CodeMemberMethod instance_method = new CodeMemberMethod();
                        instance_method.Name = "GetNewInstance";
                        instance_method.ReturnType = new CodeTypeReference(table_class.Name);
                        instance_method.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                        System.CodeDom.CodeVariableDeclarationStatement instance_var = new CodeVariableDeclarationStatement(instance_method.ReturnType, "_Instance");
                        instance_var.InitExpression = new CodeObjectCreateExpression(instance_method.ReturnType);
                        instance_method.Statements.Add(instance_var);
                        foreach (DataRow r in fields.Rows)
                        {
                            string field_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                            int field_type = int.Parse(r["user_type_id"].ToString());
                            bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                            Type _Type = SqlTypes.GetType(field_type, is_nullable);
                            if (_Type == null)
                            {
                                MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                                return;
                            }
                            CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(_Type, field_name);
                            instance_method.Parameters.Add(parameter);
                            instance_method.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(instance_var.Name + "." + field_name), new CodeSnippetExpression(parameter.Name)));
                        }
                        instance_method.Statements.Add(new System.CodeDom.CodeMethodReturnStatement(new CodeSnippetExpression(instance_var.Name)));
                        table_class.Members.Add(instance_method);
                    }
                }
                System.CodeDom.CodeMemberMethod instance_method2 = new CodeMemberMethod();
                instance_method2.Name = "GetNewInstance";
                instance_method2.ReturnType = new CodeTypeReference(table_class.Name);
                instance_method2.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                System.CodeDom.CodeVariableDeclarationStatement instance_var2 = new CodeVariableDeclarationStatement(instance_method2.ReturnType, "_Instance");
                instance_var2.InitExpression = new CodeObjectCreateExpression(instance_method2.ReturnType);
                instance_method2.Statements.Add(instance_var2);
                foreach (DataRow r in fields.Rows)
                {
                    if (!Column_Is_Identity(this.Database, table_id, r["name"].ToString()))
                    {
                        string field_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                        int field_type = int.Parse(r["user_type_id"].ToString());
                        bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                        Type _Type = SqlTypes.GetType(field_type, is_nullable);
                        if (_Type == null)
                        {
                            MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                            return;
                        }
                        CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(_Type, field_name);
                        instance_method2.Parameters.Add(parameter);
                        instance_method2.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(instance_var2.Name + "." + field_name), new CodeSnippetExpression(parameter.Name)));
                    }
                }
                instance_method2.Statements.Add(new System.CodeDom.CodeMethodReturnStatement(new CodeSnippetExpression(instance_var2.Name)));
                table_class.Members.Add(instance_method2);
                //---
                if (checkBoxAddConstractor.Checked)
                {
                    System.CodeDom.CodeConstructor constructor = new CodeConstructor();
                    constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                    table_class.Members.Add(constructor);

                    System.CodeDom.CodeConstructor constructor2 = new CodeConstructor();
                    constructor2.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                    foreach (DataRow r in fields.Rows)
                    {
                        string field_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                        int field_type = int.Parse(r["user_type_id"].ToString());
                        bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                        Type _Type = SqlTypes.GetType(field_type, is_nullable);
                        if (_Type == null)
                        {
                            MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                            return;
                        }
                        CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(_Type, field_name);
                        constructor2.Parameters.Add(parameter);
                        constructor2.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("this." + field_name), new CodeSnippetExpression(parameter.Name)));
                    }
                    table_class.Members.Add(constructor2);
                }
                //---
                System.CodeDom.CodeMemberMethod get_tableName = new CodeMemberMethod();
                get_tableName.Name = "GetTableName";
                get_tableName.ReturnType = new CodeTypeReference("System.String");
                get_tableName.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                get_tableName.Statements.Add(new System.CodeDom.CodeMethodReturnStatement(new CodeSnippetExpression("\"" + original_table_name + "\"")));
                table_class.Members.Add(get_tableName);
                //---
                //CodeParameterDeclarationExpression parameter_permission = new CodeParameterDeclarationExpression("ZeroAndOne.Sql.IPermission", "Permission");
                //CodeBinaryOperatorExpression permission_equal_null = new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(parameter_permission.Name), CodeBinaryOperatorType.IdentityInequality, new CodeSnippetExpression("null"));
                //CodeThrowExceptionStatement permission_true_statement = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(typeof(System.UnauthorizedAccessException), new CodeSnippetExpression("\"مجوز دسترسی وجود ندارد\"")));
                //---
                //----------------------
                System.CodeDom.CodeMemberMethod insert_method = new CodeMemberMethod();
                insert_method.Name = "Insert";
                insert_method.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                CodeParameterDeclarationExpression parameter_insert_datacontext = new CodeParameterDeclarationExpression(typeof(System.Data.Linq.DataContext), "DataContext");
                CodeParameterDeclarationExpression parameter_insert_new = new CodeParameterDeclarationExpression(table_class.Name, "NewInstance");
                //insert_method.Parameters.Add(parameter_permission);
                insert_method.Parameters.Add(parameter_insert_datacontext);
                insert_method.Parameters.Add(parameter_insert_new);

                //CodeMethodInvokeExpression parameter_check_table_for_insert = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(parameter_permission.Name), "CheckTablePermission", new CodeSnippetExpression("\"" + original_table_name + "\""), new CodeSnippetExpression("\"" + "Insert" + "\""));
                //CodeBinaryOperatorExpression permission_equal_false_for_insert = new CodeBinaryOperatorExpression(parameter_check_table_for_insert, CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("false"));
                //System.CodeDom.CodeConditionStatement permission_check_for_insert = new CodeConditionStatement(permission_equal_false_for_insert, permission_true_statement);
                //System.CodeDom.CodeConditionStatement permission_full_check_for_insert = new CodeConditionStatement(permission_equal_null, permission_check_for_insert);
                //insert_method.Statements.Add(permission_full_check_for_insert);

                insert_method.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeVariableReferenceExpression(parameter_insert_datacontext.Name), "GetTable<" + fixed_table_name + ">()"), "InsertOnSubmit", new CodeVariableReferenceExpression(parameter_insert_new.Name)));
                table_class.Members.Add(insert_method);
                //----------------------
                System.CodeDom.CodeMemberMethod update_method = new CodeMemberMethod();
                update_method.Name = "Copy";
                update_method.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                CodeParameterDeclarationExpression parameter_update_original = new CodeParameterDeclarationExpression(table_class.Name, "OriginalInstance");
                CodeParameterDeclarationExpression parameter_update_new = new CodeParameterDeclarationExpression(table_class.Name, "NewInstance");
                //update_method.Parameters.Add(parameter_permission);
                update_method.Parameters.Add(parameter_update_original);
                update_method.Parameters.Add(parameter_update_new);

                //CodeMethodInvokeExpression parameter_check_table_for_update = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(parameter_permission.Name), "CheckTablePermission", new CodeSnippetExpression("\"" + original_table_name + "\""), new CodeSnippetExpression("\"" + "Update" + "\""));
                //CodeBinaryOperatorExpression permission_equal_false_for_update = new CodeBinaryOperatorExpression(parameter_check_table_for_update, CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("false"));
                //System.CodeDom.CodeConditionStatement permission_check_for_update = new CodeConditionStatement(permission_equal_false_for_update, permission_true_statement);
                //System.CodeDom.CodeConditionStatement permission_full_check_for_update = new CodeConditionStatement(permission_equal_null, permission_check_for_update);
                //update_method.Statements.Add(permission_full_check_for_update);

                foreach (DataRow r in fields.Rows)
                {
                    if (!Column_Is_Identity(this.Database, table_id, r["name"].ToString()))
                    {
                        string field_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                        int field_type = int.Parse(r["user_type_id"].ToString());
                        bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                        Type _Type = SqlTypes.GetType(field_type, is_nullable);
                        if (_Type == null)
                        {
                            MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                            return;
                        }
                        update_method.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(parameter_update_original.Name + "." + field_name), new CodeSnippetExpression(parameter_update_new.Name + "." + field_name)));
                    }
                }
                table_class.Members.Add(update_method);
                //----------------------
                System.CodeDom.CodeMemberMethod delete_method = new CodeMemberMethod();
                delete_method.Name = "Delete";
                delete_method.Attributes = MemberAttributes.Public | MemberAttributes.Final | MemberAttributes.Static;
                CodeParameterDeclarationExpression parameter_delete_datacontext = new CodeParameterDeclarationExpression(typeof(System.Data.Linq.DataContext), "DataContext");
                CodeParameterDeclarationExpression parameter_delete_object = new CodeParameterDeclarationExpression(table_class.Name, "OriginalInstance");
                //delete_method.Parameters.Add(parameter_permission);
                delete_method.Parameters.Add(parameter_delete_datacontext);
                delete_method.Parameters.Add(parameter_delete_object);

                //CodeMethodInvokeExpression parameter_check_table_for_delete = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(parameter_permission.Name), "CheckTablePermission", new CodeSnippetExpression("\"" + original_table_name + "\""), new CodeSnippetExpression("\"" + "Delete" + "\""));
                //CodeBinaryOperatorExpression permission_equal_false_for_delete = new CodeBinaryOperatorExpression(parameter_check_table_for_delete, CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("false"));
                //System.CodeDom.CodeConditionStatement permission_check_for_delete = new CodeConditionStatement(permission_equal_false_for_delete, permission_true_statement);
                //System.CodeDom.CodeConditionStatement permission_full_check_for_delete = new CodeConditionStatement(permission_equal_null, permission_check_for_delete);
                //delete_method.Statements.Add(permission_full_check_for_delete);

                delete_method.Statements.Add(new CodeMethodInvokeExpression(new CodeMethodReferenceExpression(new CodeVariableReferenceExpression(parameter_delete_datacontext.Name), "GetTable<" + fixed_table_name + ">()"), "DeleteOnSubmit", new CodeVariableReferenceExpression(parameter_delete_object.Name)));
                table_class.Members.Add(delete_method);
                //----------------------
                if (checkBox_create_property.Checked)
                {
                    foreach (DataRow r in fields.Rows)
                    {
                        string field_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                        int field_type = int.Parse(r["user_type_id"].ToString());
                        bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                        System.CodeDom.CodeMemberField MemberField;
                        System.CodeDom.CodeMemberProperty MemberProperty;
                        Type _Type = SqlTypes.GetType(field_type, is_nullable);
                        if (_Type == null)
                        {
                            MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                            return;
                        }
                        MemberField = new CodeMemberField(_Type, "_" + RemoveAtSign(field_name));
                        MemberField.Attributes = MemberAttributes.Private;
                        MemberProperty = new CodeMemberProperty();
                        MemberProperty.Name = field_name;
                        MemberProperty.HasGet = true;
                        MemberProperty.HasSet = true;
                        MemberProperty.Attributes = MemberAttributes.Public;
                        MemberProperty.Attributes |= MemberAttributes.Final;
                        MemberProperty.Type = MemberField.Type;
                        MemberProperty.GetStatements.Add(new System.CodeDom.CodeMethodReturnStatement(new CodeSnippetExpression(MemberField.Name)));
                        MemberProperty.SetStatements.Add(new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(MemberField.Name), new CodeSnippetExpression("value")));
                        if (checkBox_use_comment.Checked)
                        {
                            CodeCommentStatement field_comment = new CodeCommentStatement("----------------------");
                            MemberField.Comments.Add(field_comment);
                        }
                        table_class.Members.Add(MemberField);
                        table_class.Members.Add(MemberProperty);
                    }
                }
            }
            CSharpCodeProvider myCodeProvider = new CSharpCodeProvider();
            //string temp_file_name = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileName(txt_filename.Text));
            //string filePath = txt_filename.Text;
            StringBuilder generatedCode = new StringBuilder();
            StringWriter codeWriter = new StringWriter(generatedCode);
            ICodeGenerator myCodeGenerator = myCodeProvider.CreateGenerator(codeWriter);
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BlankLinesBetweenMembers = false;
            options.BracingStyle = "C";
            options.ElseOnClosing = true;
            options.VerbatimOrder = true;
            try
            {
                if (name_space != null)
                    myCodeGenerator.GenerateCodeFromNamespace(name_space, codeWriter, options);
                else
                {
                    foreach (var item in class_list)
                    {
                        myCodeGenerator.GenerateCodeFromType(item, codeWriter, options);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در تولید کد" + "\n\n" + ex.Message);
            }
            //if (checkBox_openfile.Checked)
            //{
            ShowCode _ShowCode = new ShowCode(generatedCode.ToString());
            _ShowCode.ShowDialog();
            //}
            //else
            //{
            //    try
            //    {
            //        System.IO.File.WriteAllText(filePath, generatedCode.ToString(), Encoding.UTF8);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("خطا در ذخیره ی کد تولید شده" + "\n\n" + ex.Message);
            //        ShowCode _ShowCode = new ShowCode(generatedCode.ToString(), filePath);
            //        _ShowCode.ShowDialog();
            //        return;
            //    }
            //}
            //foreach (EnvDTE.ProjectItem item in active_project.ProjectItems)
            //{
            //    if (item.Name == System.IO.Path.GetFileName(temp_file_name))
            //    {
            //        DialogResult result = MessageBox.Show("فایل" + "\n" + item.Name + "\n" + "از قبل در پروژه وجود دارد. محتوای این فایل جایگزین شود؟", "تایید جایگزینی", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            //        if (result == DialogResult.Yes)
            //            item.Delete();
            //        else
            //            return;
            //    }
            //}
            //EnvDTE.ProjectItem p_item = active_project.ProjectItems.AddFromFileCopy(temp_file_name);
            //if (checkBox_openfile.Checked)
            //{
            //    EnvDTE.Window i_window = p_item.Open(EnvDTE.Constants.vsViewKindCode);
            //    i_window.Activate();
            //}
            //try
            //{
            //    System.IO.File.Delete(temp_file_name);
            //}
            //catch { }
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Generator_Load(object sender, EventArgs e)
        {
            if (!Namespace_Changed)
                txt_namespace.Text = this.Database + "Classes";
            //if (!Filename_Changed)
            //{
            //    if (this.Tables.Count > 1)
            //        txt_filename.Text = this.Database + "Classes.cs";
            //    else if (this.Tables.Count == 1)
            //        txt_filename.Text = this.Tables[0] + ".cs";
            //}
        }
    }
}
