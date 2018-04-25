using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;

namespace DataCodeGenerator.UI
{
    public partial class TableAdapterGenerator : DataCodeGenerator.UI.GeneratorBase
    {
        public TableAdapterGenerator()
        {
            InitializeComponent();
        }

        private static TableAdapterGenerator _Instance;
        public static TableAdapterGenerator GetInstance(string Database, List<string> Tables)
        {
            if (_Instance == null)
                _Instance = new TableAdapterGenerator();
            if (_Instance.IsDisposed)
                _Instance = new TableAdapterGenerator();
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
                string fixed_table_name = FixName(original_table_name, false, checkBox_to_upper.Checked, false);
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
                CodeTypeDeclaration table_class = new CodeTypeDeclaration(RemoveAtSign(fixed_table_name) + "TableAdapter");
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

                CodeMemberField _SqlConnection = new CodeMemberField(typeof(System.Data.SqlClient.SqlConnection), "_Connection");
                CodeMemberField _SqlCommand = new CodeMemberField(typeof(System.Data.SqlClient.SqlCommand), "_Command");
                CodeMemberField _SqlDataAdapter = new CodeMemberField(typeof(System.Data.SqlClient.SqlDataAdapter), "_DataAdapter");
                CodeMemberField _Transaction = new CodeMemberField(typeof(System.Data.SqlClient.SqlTransaction), "_Transaction");
                table_class.Members.Add(_SqlConnection);
                table_class.Members.Add(_SqlCommand);
                table_class.Members.Add(_SqlDataAdapter);
                table_class.Members.Add(_Transaction);
                //----------------------
                System.CodeDom.CodeConstructor constructor = new CodeConstructor();
                constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                CodeParameterDeclarationExpression constructor_parameter = new CodeParameterDeclarationExpression(typeof(string), "ConnectionString");
                constructor.Parameters.Add(constructor_parameter);
                System.CodeDom.CodeAssignStatement sqlConnectionAssign = new CodeAssignStatement(new CodeSnippetExpression(_SqlConnection.Name), new System.CodeDom.CodeObjectCreateExpression(typeof(System.Data.SqlClient.SqlConnection), new CodeSnippetExpression(constructor_parameter.Name)));
                System.CodeDom.CodeAssignStatement sqlCommandAssign = new CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name), new System.CodeDom.CodeObjectCreateExpression(typeof(System.Data.SqlClient.SqlCommand)));
                System.CodeDom.CodeAssignStatement sqlDataAdapterAssign = new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name), new System.CodeDom.CodeObjectCreateExpression(typeof(System.Data.SqlClient.SqlDataAdapter)));

                System.CodeDom.CodeAssignStatement sqlDataAdapterSelectCommandAssign = new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".SelectCommand"), new System.CodeDom.CodeObjectCreateExpression(typeof(System.Data.SqlClient.SqlCommand)));
                System.CodeDom.CodeAssignStatement sqlDataAdapterDeleteCommandAssign = new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".DeleteCommand"), new System.CodeDom.CodeObjectCreateExpression(typeof(System.Data.SqlClient.SqlCommand)));
                System.CodeDom.CodeAssignStatement sqlDataAdapterUpdateCommandAssign = new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".UpdateCommand"), new System.CodeDom.CodeObjectCreateExpression(typeof(System.Data.SqlClient.SqlCommand)));

                constructor.Statements.Add(sqlConnectionAssign);
                constructor.Statements.Add(sqlCommandAssign);
                constructor.Statements.Add(sqlDataAdapterAssign);
                constructor.Statements.Add(sqlDataAdapterSelectCommandAssign);
                constructor.Statements.Add(sqlDataAdapterDeleteCommandAssign);
                constructor.Statements.Add(sqlDataAdapterUpdateCommandAssign);
                constructor.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name + ".Connection"), new CodeSnippetExpression(_SqlConnection.Name)));
                constructor.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".SelectCommand.Connection"), new CodeSnippetExpression(_SqlConnection.Name)));
                constructor.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".DeleteCommand.Connection"), new CodeSnippetExpression(_SqlConnection.Name)));
                constructor.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".UpdateCommand.Connection"), new CodeSnippetExpression(_SqlConnection.Name)));
                table_class.Members.Add(constructor);
                //----------------------
                CodeMemberProperty connectionProperty = new CodeMemberProperty();
                connectionProperty.Name = "Connection";
                connectionProperty.HasGet = true;
                connectionProperty.HasSet = true;
                connectionProperty.Attributes = MemberAttributes.Public;
                connectionProperty.Attributes |= MemberAttributes.Final;
                connectionProperty.Type = _SqlConnection.Type;
                connectionProperty.GetStatements.Add(new System.CodeDom.CodeMethodReturnStatement(new CodeSnippetExpression(_SqlConnection.Name)));
                CodeAssignStatement connectionSetStatement1 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlConnection.Name), new CodeSnippetExpression("value"));
                CodeAssignStatement connectionSetStatement2 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name + ".Connection"), new CodeSnippetExpression("value"));
                CodeAssignStatement connectionSetStatement3 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".SelectCommand.Connection"), new CodeSnippetExpression("value"));
                CodeAssignStatement connectionSetStatement4 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".DeleteCommand.Connection"), new CodeSnippetExpression("value"));
                CodeAssignStatement connectionSetStatement5 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".UpdateCommand.Connection"), new CodeSnippetExpression("value"));
                connectionProperty.SetStatements.Add(connectionSetStatement1);
                connectionProperty.SetStatements.Add(connectionSetStatement2);
                connectionProperty.SetStatements.Add(connectionSetStatement3);
                connectionProperty.SetStatements.Add(connectionSetStatement4);
                connectionProperty.SetStatements.Add(connectionSetStatement5);
                table_class.Members.Add(connectionProperty);
                //----------------------
                CodeMemberProperty transactionProperty = new CodeMemberProperty();
                transactionProperty.Name = "Transaction";
                transactionProperty.HasGet = true;
                transactionProperty.HasSet = true;
                transactionProperty.Attributes = MemberAttributes.Public;
                transactionProperty.Attributes |= MemberAttributes.Final;
                transactionProperty.Type = new CodeTypeReference(typeof(System.Data.SqlClient.SqlTransaction));
                transactionProperty.GetStatements.Add(new System.CodeDom.CodeMethodReturnStatement(new CodeSnippetExpression(_Transaction.Name)));
                CodeAssignStatement transactionSetStatement1 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_Transaction.Name), new CodeSnippetExpression("value"));
                CodeAssignStatement transactionSetStatement2 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name + ".Transaction"), new CodeSnippetExpression("value"));
                CodeAssignStatement transactionSetStatement3 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".SelectCommand.Transaction"), new CodeSnippetExpression("value"));
                CodeAssignStatement transactionSetStatement4 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".DeleteCommand.Transaction"), new CodeSnippetExpression("value"));
                CodeAssignStatement transactionSetStatement5 = new System.CodeDom.CodeAssignStatement(new CodeSnippetExpression(_SqlDataAdapter.Name + ".UpdateCommand.Transaction"), new CodeSnippetExpression("value"));
                transactionProperty.SetStatements.Add(transactionSetStatement1);
                transactionProperty.SetStatements.Add(transactionSetStatement2);
                transactionProperty.SetStatements.Add(transactionSetStatement3);
                transactionProperty.SetStatements.Add(transactionSetStatement4);
                transactionProperty.SetStatements.Add(transactionSetStatement5);
                table_class.Members.Add(transactionProperty);
                //---
                //CodeParameterDeclarationExpression parameter_permission = new CodeParameterDeclarationExpression("ZeroAndOne.Sql.IPermission", "Permission");
                //CodeBinaryOperatorExpression permission_equal_null = new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(parameter_permission.Name), CodeBinaryOperatorType.IdentityInequality, new CodeSnippetExpression("null"));
                //CodeThrowExceptionStatement permission_true_statement = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(typeof(System.UnauthorizedAccessException), new CodeSnippetExpression("\"مجوز دسترسی وجود ندارد\"")));
                //---
                //----------------------
                if (fields.Rows.Count > 0)
                {
                    System.CodeDom.CodeMemberMethod insert_method = new CodeMemberMethod();
                    insert_method.Name = "Insert";
                    insert_method.ReturnType = new CodeTypeReference(typeof(int));
                    insert_method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                    string insert_values_statement = "";
                    string insert_field_names = "";
                    List<CodeSnippetExpression> command_parameters = new List<CodeSnippetExpression>();
                    int parameter_index = 0;
                    //insert_method.Parameters.Add(parameter_permission);
                    foreach (DataRow r in fields.Rows)
                    {
                        string field_var_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                        int field_var_type = int.Parse(r["user_type_id"].ToString());
                        bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                        Type _Type = SqlTypes.GetType(field_var_type, is_nullable);
                        if (_Type == null)
                        {
                            MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                            return;
                        }
                        CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(_Type, field_var_name);
                        insert_method.Parameters.Add(parameter);
                        insert_field_names += "[" + r["name"].ToString() + "]";
                        insert_values_statement += "@p" + parameter_index.ToString();
                        command_parameters.Add(new CodeSnippetExpression(_SqlCommand.Name + ".Parameters.AddWithValue(" + "\"" + "@p" + parameter_index.ToString() + "\"" + ", " + field_var_name + ")"));
                        if ((parameter_index + 1) < fields.Rows.Count)
                        {
                            insert_values_statement += ", ";
                            insert_field_names += ", ";
                        }
                        parameter_index++;
                    }
                    //CodeMethodInvokeExpression parameter_check_table_for_insert = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(parameter_permission.Name), "CheckTablePermission", new CodeSnippetExpression("\"" + original_table_name + "\""), new CodeSnippetExpression("\"" + "Insert" + "\""));
                    //CodeBinaryOperatorExpression permission_equal_false_for_insert = new CodeBinaryOperatorExpression(parameter_check_table_for_insert, CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("false"));
                    //System.CodeDom.CodeConditionStatement permission_check_for_insert = new CodeConditionStatement(permission_equal_false_for_insert, permission_true_statement);
                    //System.CodeDom.CodeConditionStatement permission_full_check_for_insert = new CodeConditionStatement(permission_equal_null, permission_check_for_insert);
                    //insert_method.Statements.Add(permission_full_check_for_insert);

                    CodeSnippetExpression parameters_clear = new CodeSnippetExpression(_SqlCommand.Name + ".Parameters.Clear();");
                    insert_method.Statements.Add(parameters_clear);
                    CodeAssignStatement insertStatement1 = new CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name + ".CommandText"), new CodeSnippetExpression(string.Format("\"INSERT INTO [{0}] ({1}) VALUES({2})\"", original_table_name, insert_field_names, insert_values_statement)));
                    insert_method.Statements.Add(insertStatement1);
                    foreach (var item in command_parameters)
                    {
                        insert_method.Statements.Add(item);
                    }
                    CodeVariableDeclarationStatement previousConnectionState = new CodeVariableDeclarationStatement(typeof(System.Data.ConnectionState), "previousConnectionState");
                    previousConnectionState.InitExpression = new CodeSnippetExpression(_SqlConnection.Name + ".State");
                    insert_method.Statements.Add(previousConnectionState);

                    CodeBinaryOperatorExpression and = new CodeBinaryOperatorExpression(new CodeSnippetExpression(_SqlConnection.Name + ".State"), CodeBinaryOperatorType.BitwiseAnd, new CodeSnippetExpression("System.Data.ConnectionState.Open"));
                    CodeBinaryOperatorExpression equal = new CodeBinaryOperatorExpression(and, CodeBinaryOperatorType.IdentityInequality, new CodeSnippetExpression("System.Data.ConnectionState.Open"));
                    CodeStatement[] if_try_statements = new CodeStatement[1];
                    if_try_statements[0] = new CodeSnippetStatement("\t\t\t\t\t" + _SqlConnection.Name + ".Open();");
                    CodeCatchClause[] if_catch_statements = new CodeCatchClause[1];
                    if_catch_statements[0] = new CodeCatchClause("ex", new CodeTypeReference(typeof(System.Exception)), new CodeSnippetStatement("\t\t\t\t\tthrow new System.Exception(\"ارتباط با سرور پایگاه داده برقرار نیست\" + \"\\n\\n\" + ex.Message);"));
                    CodeTryCatchFinallyStatement if_true_statement = new CodeTryCatchFinallyStatement(if_try_statements, if_catch_statements);
                    CodeConditionStatement check_connection_state = new CodeConditionStatement(equal, if_true_statement);

                    insert_method.Statements.Add(check_connection_state);

                    CodeVariableDeclarationStatement i = new CodeVariableDeclarationStatement(typeof(int), "i");
                    insert_method.Statements.Add(i);
                    CodeStatement[] try_statements = new CodeStatement[1];
                    try_statements[0] = new CodeAssignStatement(new CodeVariableReferenceExpression(i.Name), new CodeSnippetExpression(_SqlCommand.Name + ".ExecuteNonQuery()"));
                    CodeStatement[] finally_statements = new CodeStatement[1];

                    CodeBinaryOperatorExpression equal_closed = new CodeBinaryOperatorExpression(new CodeVariableReferenceExpression(previousConnectionState.Name), CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("System.Data.ConnectionState.Closed"));
                    CodeConditionStatement check_connection_closed = new CodeConditionStatement(equal_closed, new CodeSnippetStatement("\t\t\t\t\t" + _SqlConnection.Name + ".Close();"));
                    finally_statements[0] = check_connection_closed;
                    CodeTryCatchFinallyStatement try_catch = new CodeTryCatchFinallyStatement(try_statements, new CodeCatchClause[0], finally_statements);
                    insert_method.Statements.Add(try_catch);
                    CodeMethodReturnStatement return_i = new CodeMethodReturnStatement(new CodeVariableReferenceExpression(i.Name));
                    insert_method.Statements.Add(return_i);

                    table_class.Members.Add(insert_method);
                    //----------------------
                    System.CodeDom.CodeMemberMethod update_method = new CodeMemberMethod();
                    update_method.Name = "Update";
                    update_method.ReturnType = new CodeTypeReference(typeof(int));
                    update_method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                    string update_set_statement = "";
                    command_parameters = new List<CodeSnippetExpression>();
                    parameter_index = 0;
                    //update_method.Parameters.Add(parameter_permission);
                    foreach (DataRow r in fields.Rows)
                    {
                        string field_var_name = FixName(r["name"].ToString(), false, checkBox_to_upper.Checked, false);
                        int field_var_type = int.Parse(r["user_type_id"].ToString());
                        bool is_nullable = bool.Parse(r["is_nullable"].ToString());
                        Type _Type = SqlTypes.GetType(field_var_type, is_nullable);
                        if (_Type == null)
                        {
                            MessageBox.Show("نوع فیلد پشتیبانی نمی شود" + Environment.NewLine + "جدول: " + original_table_name + " فیلد: " + r["name"].ToString());
                            return;
                        }
                        CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(_Type, field_var_name);
                        update_method.Parameters.Add(parameter);
                        update_set_statement += "[" + r["name"].ToString() + "]=" + "@p" + parameter_index.ToString();
                        command_parameters.Add(new CodeSnippetExpression(_SqlCommand.Name + ".Parameters.AddWithValue(" + "\"" + "@p" + parameter_index.ToString() + "\"" + ", " + field_var_name + ")"));
                        if ((parameter_index + 1) < fields.Rows.Count)
                        {
                            update_set_statement += ", ";
                        }
                        parameter_index++;
                    }

                    //CodeMethodInvokeExpression parameter_check_table_for_update = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(parameter_permission.Name), "CheckTablePermission", new CodeSnippetExpression("\"" + original_table_name + "\""), new CodeSnippetExpression("\"" + "Update" + "\""));
                    //CodeBinaryOperatorExpression permission_equal_false_for_update = new CodeBinaryOperatorExpression(parameter_check_table_for_update, CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("false"));
                    //System.CodeDom.CodeConditionStatement permission_check_for_update = new CodeConditionStatement(permission_equal_false_for_update, permission_true_statement);
                    //System.CodeDom.CodeConditionStatement permission_full_check_for_update = new CodeConditionStatement(permission_equal_null, permission_check_for_update);
                    //update_method.Statements.Add(permission_full_check_for_update);

                    string field0_var_name = FixName(fields.Rows[0]["name"].ToString(), false, checkBox_to_upper.Checked, false);
                    int field0_var_type = int.Parse(fields.Rows[0]["user_type_id"].ToString());
                    bool field0_is_nullable = bool.Parse(fields.Rows[0]["is_nullable"].ToString());
                    Type _field0_Type = SqlTypes.GetType(field0_var_type, field0_is_nullable);
                    CodeParameterDeclarationExpression update_original_key_parameter = new CodeParameterDeclarationExpression(_field0_Type, "Original_" + field0_var_name);
                    update_method.Parameters.Add(update_original_key_parameter);

                    update_method.Statements.Add(parameters_clear);
                    CodeAssignStatement updateStatement1 = new CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name + ".CommandText"), new CodeSnippetExpression(string.Format("\"Update [{0}] SET {1} WHERE {2}\"", original_table_name, update_set_statement, fields.Rows[0]["name"].ToString() + "=@originalkey")));
                    update_method.Statements.Add(updateStatement1);
                    command_parameters.Add(new CodeSnippetExpression(_SqlCommand.Name + ".Parameters.AddWithValue(" + "\"" + "@originalkey" + "\"" + ", " + update_original_key_parameter.Name + ")"));
                    foreach (var item in command_parameters)
                    {
                        update_method.Statements.Add(item);
                    }
                    update_method.Statements.Add(previousConnectionState);
                    update_method.Statements.Add(check_connection_state);
                    update_method.Statements.Add(i);
                    update_method.Statements.Add(try_catch);
                    update_method.Statements.Add(return_i);
                    table_class.Members.Add(update_method);
                    //----------------------
                    System.CodeDom.CodeMemberMethod delete_method = new CodeMemberMethod();
                    delete_method.Name = "Delete";
                    delete_method.ReturnType = new CodeTypeReference(typeof(int));
                    delete_method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                    //delete_method.Parameters.Add(parameter_permission);
                    string delete_method_field_var_name = FixName(fields.Rows[0]["name"].ToString(), false, checkBox_to_upper.Checked, false);
                    int delete_method_field_var_type = int.Parse(fields.Rows[0]["user_type_id"].ToString());
                    bool delete_method_field_is_nullable = bool.Parse(fields.Rows[0]["is_nullable"].ToString());
                    Type delete_method_field_Type = SqlTypes.GetType(delete_method_field_var_type, delete_method_field_is_nullable);
                    CodeParameterDeclarationExpression delete_method_parameter = new CodeParameterDeclarationExpression(delete_method_field_Type, "Original_" + delete_method_field_var_name);
                    delete_method.Parameters.Add(delete_method_parameter);

                    //CodeMethodInvokeExpression parameter_check_table_for_delete = new CodeMethodInvokeExpression(new CodeVariableReferenceExpression(parameter_permission.Name), "CheckTablePermission", new CodeSnippetExpression("\"" + original_table_name + "\""), new CodeSnippetExpression("\"" + "Delete" + "\""));
                    //CodeBinaryOperatorExpression permission_equal_false_for_delete = new CodeBinaryOperatorExpression(parameter_check_table_for_delete, CodeBinaryOperatorType.IdentityEquality, new CodeSnippetExpression("false"));
                    //System.CodeDom.CodeConditionStatement permission_check_for_delete = new CodeConditionStatement(permission_equal_false_for_delete, permission_true_statement);
                    //System.CodeDom.CodeConditionStatement permission_full_check_for_delete = new CodeConditionStatement(permission_equal_null, permission_check_for_delete);
                    //delete_method.Statements.Add(permission_full_check_for_delete);

                    delete_method.Statements.Add(parameters_clear);
                    CodeAssignStatement deleteStatement1 = new CodeAssignStatement(new CodeSnippetExpression(_SqlCommand.Name + ".CommandText"), new CodeSnippetExpression(string.Format("\"DELETE FROM [{0}] WHERE {1}\"", original_table_name, "[" + fields.Rows[0]["name"].ToString() + "]" + "=@originalkey")));
                    delete_method.Statements.Add(deleteStatement1);
                    delete_method.Statements.Add(new CodeSnippetExpression(_SqlCommand.Name + ".Parameters.AddWithValue(" + "\"" + "@originalkey" + "\"" + ", " + delete_method_parameter.Name + ")"));
                    delete_method.Statements.Add(previousConnectionState);
                    delete_method.Statements.Add(check_connection_state);
                    delete_method.Statements.Add(i);
                    delete_method.Statements.Add(try_catch);
                    delete_method.Statements.Add(return_i);
                    table_class.Members.Add(delete_method);
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
            ShowCode _ShowCode = new ShowCode(generatedCode.ToString());
            _ShowCode.ShowDialog();
            //try
            //{
            //    System.IO.File.WriteAllText(filePath, generatedCode.ToString(), Encoding.UTF8);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("خطا در ذخیره ی کد تولید شده" + "\n\n" + ex.Message);
            //    ShowCode _ShowCode = new ShowCode(generatedCode.ToString(), filePath);
            //    _ShowCode.ShowDialog();
            //    return;
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

        private void TableAdapterGenerator_Load(object sender, EventArgs e)
        {
            if (!Namespace_Changed)
                txt_namespace.Text = this.Database + "TableAdapters";
            //if (!Filename_Changed)
            //{
            //    if (this.Tables.Count > 1)
            //        txt_filename.Text = this.Database + "TableAdapters.cs";
            //    else if (this.Tables.Count == 1)
            //        txt_filename.Text = this.Tables[0] + "TableAdapter" + ".cs";
            //}
        }
    }
}
