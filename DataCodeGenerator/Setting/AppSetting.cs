using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataCodeGenerator.Setting
{
    internal class AppSetting
    {
        private static AppSetting _Instance;

        public static AppSetting Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new AppSetting();
                return _Instance;
            }
        }

        private List<string> _NamespaceList = new List<string>();

        public List<string> NamespaceList
        {
            get
            {
                return _NamespaceList;
            }
            set
            {
                _NamespaceList = value;
            }
        }

        internal void Load()
        {
            string file = GetFileName();
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                _NamespaceList.Clear();
                foreach (string item in lines)
                {
                    if (item.Trim() != "")
                        _NamespaceList.Add(item);
                }
            }
        }

        private static string GetFileName()
        {
            return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "AppSetting.json");
        }

        internal void Save()
        {
            string s = "";
            foreach (string item in _NamespaceList)
            {
                s += item + Environment.NewLine;
            }
            s = s.Trim();
            File.WriteAllText(GetFileName(), s);
        }
    }
}