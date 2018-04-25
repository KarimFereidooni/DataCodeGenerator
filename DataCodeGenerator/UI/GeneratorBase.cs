using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCodeGenerator.UI
{
    public partial class GeneratorBase : Form
    {
        public GeneratorBase()
        {
            InitializeComponent();
            //active_project = null;
            Tables = new List<string>();
            Database = "";
        }

        //protected EnvDTE.Project active_project;
        protected List<string> Tables;

        protected string Database;

        private void GeneratorBase_Load(object sender, EventArgs e)
        {
            //if (!DesignMode)
            //{
            //    System.Array solution_projects = (System.Array)UI.Main.Instance.ApplicationObject.ActiveSolutionProjects;
            //    if (solution_projects.Length > 0)
            //    {
            //        active_project = (EnvDTE.Project)(solution_projects.GetValue(0));
            //        lbl_active_project.Text = active_project.Name;
            //    }
            //}
            Setting.AppSetting.Instance.Load();
            txt_namespace.Items.Clear();
            foreach (string item in Setting.AppSetting.Instance.NamespaceList)
            {
                txt_namespace.Items.Add(item);
            }
        }

        public static string FixName(string Name, bool UseUnderLine, bool FirstCharToUpper, bool DeleteS)
        {
            if (FirstCharToUpper)
            {
                string first_char = Name[0].ToString();
                first_char = first_char.ToUpper();
                Name = Name.Substring(1);
                Name = first_char + Name;
            }
            if (DeleteS && !(WordsWithsWithSContains(Name.ToLower())))
            {
                if (Name.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
                    Name = Name.Substring(0, Name.Length - 1);
            }
            if (CSharpReservedNames.Contains(Name))
            {
                if (UseUnderLine)
                    return "_" + Name;
                return "@" + Name;
            }
            else
                return Name;
        }

        private static bool WordsWithsWithSContains(string p)
        {
            foreach (var item in WordsWithsWithS)
            {
                if (p.EndsWith(item))
                    return true;
            }
            return false;
        }

        private static List<string> _WordsWithsWithS;

        public static List<string> WordsWithsWithS
        {
            get
            {
                if (_WordsWithsWithS == null)
                {
                    _WordsWithsWithS = new List<string>();
                    _WordsWithsWithS.Add("class");
                    _WordsWithsWithS.Add("news");
                    _WordsWithsWithS.Add("status");
                    _WordsWithsWithS.Add("bonus");
                    _WordsWithsWithS.Add("pass");
                }
                return _WordsWithsWithS;
            }
            set
            {
                _WordsWithsWithS = value;
            }
        }

        private static List<string> _CSharpReservedNames;

        public static List<string> CSharpReservedNames
        {
            get
            {
                if (_CSharpReservedNames == null)
                {
                    _CSharpReservedNames = new List<string>();
                    _CSharpReservedNames.Add("class");
                    _CSharpReservedNames.Add("string");
                    _CSharpReservedNames.Add("int");
                    _CSharpReservedNames.Add("float");
                    _CSharpReservedNames.Add("double");
                    _CSharpReservedNames.Add("decimal");
                    _CSharpReservedNames.Add("enum");
                    _CSharpReservedNames.Add("private");
                    _CSharpReservedNames.Add("public");
                    _CSharpReservedNames.Add("void");
                    _CSharpReservedNames.Add("object");
                    _CSharpReservedNames.Add("this");
                    _CSharpReservedNames.Add("new");
                    _CSharpReservedNames.Add("return");
                    _CSharpReservedNames.Add("interface");
                    _CSharpReservedNames.Add("null");
                    _CSharpReservedNames.Add("value");
                    _CSharpReservedNames.Add("try");
                    _CSharpReservedNames.Add("catch");
                    _CSharpReservedNames.Add("finally");
                    _CSharpReservedNames.Add("true");
                    _CSharpReservedNames.Add("false");
                    _CSharpReservedNames.Add("for");
                    _CSharpReservedNames.Add("foreach");
                    _CSharpReservedNames.Add("if");
                    _CSharpReservedNames.Add("else");
                    _CSharpReservedNames.Add("partial");
                    _CSharpReservedNames.Add("using");
                    _CSharpReservedNames.Add("namespace");
                    _CSharpReservedNames.Add("abstract");
                    _CSharpReservedNames.Add("override");
                }
                return _CSharpReservedNames;
            }
            set
            {
                _CSharpReservedNames = value;
            }
        }

        public static string GetIdentityColumn(string Database, string Table_Id)
        {
            DataTable fields = GetFields(Database, Table_Id);
            foreach (DataRow row in fields.Rows)
            {
                if (Column_Is_Identity(Database, Table_Id, row["name"].ToString()))
                    return row["name"].ToString();
            }
            return null;
        }

        public static bool Column_Is_Identity(string Database, string Table_Id, string ColumnName)
        {
            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(Database);
                object obj = DataAccess.Instance.ExecuteScalar("SELECT [is_identity] FROM [sys].[all_columns] WHERE [object_id]=@table_id AND [name]=@name", "@table_id", Table_Id, "@name", ColumnName);
                if (obj == null)
                    return false;
                bool Is_Identity;
                if (bool.TryParse(obj.ToString(), out Is_Identity))
                    return Is_Identity;
                int i;
                if (int.TryParse(obj.ToString(), out i))
                    return i == 1 ? true : false;
                return false;
            }
            finally
            {
                DataAccess.Instance.Connection.Close();
            }
        }

        public static DataTable GetFields(string Database, string Table_Id)
        {
            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(Database);
                return DataAccess.Instance.GetData("SELECT * FROM [sys].[all_columns] WHERE [object_id]=@table_id", "@table_id", Table_Id);
            }
            catch
            {
                return null;
            }
            finally
            {
                DataAccess.Instance.Connection.Close();
            }
        }

        public static string GetTableID(string Database, string Table_Name)
        {
            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(Database);
                return DataAccess.Instance.ExecuteScalar("SELECT [object_id] FROM [sys].[all_objects] WHERE [name]=@name", "@name", Table_Name).ToString();
            }
            catch
            {
                return null;
            }
            finally
            {
                DataAccess.Instance.Connection.Close();
            }
        }

        public string RemoveAtSign(string Name)
        {
            return Name.Replace("@", "");
        }

        protected bool Namespace_Changed = false;

        private void txt_namespace_KeyDown(object sender, KeyEventArgs e)
        {
            Namespace_Changed = true;
        }

        protected bool Filename_Changed = false;

        private void txt_filename_KeyDown(object sender, KeyEventArgs e)
        {
            Filename_Changed = true;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            Setting.AppSetting.Instance.NamespaceList.Clear();
            if (!txt_namespace.Items.Contains(txt_namespace.Text))
                Setting.AppSetting.Instance.NamespaceList.Add(txt_namespace.Text);
            foreach (var item in txt_namespace.Items)
            {
                Setting.AppSetting.Instance.NamespaceList.Add(item.ToString());
            }
            Setting.AppSetting.Instance.Save();
        }
    }
}