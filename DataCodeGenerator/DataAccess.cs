using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DataCodeGenerator
{
    class DataAccess
    {
        private static DataAccess _Instance;
        public static DataAccess Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new DataAccess(@"Data Source=.\ZAO;Initial Catalog=Master;Integrated Security=True");
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }
        public SqlConnection Connection;
        public SqlCommand Command;
        public SqlDataAdapter Adapter;
        //---------------------------------
        public DataAccess(string ConnectionString)
        {
            Connection = new SqlConnection(ConnectionString);
            Command = new SqlCommand("", Connection);
            Adapter = new SqlDataAdapter("", Connection);
        }
        //---------------------------------------------------------------------------------
        #region IDataAccessMain Members

        public int Execute(string command, params object[] parameters)
        {
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            int i;
            try
            {
                i = Command.ExecuteNonQuery();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }
        //-------------------------------------------------------------------------------
        public object ExecuteScalar(string command, params object[] parameters)
        {
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            System.Data.ConnectionState previousConnectionState = Connection.State;
            if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + ex.Message);
                }
            }
            object i;
            try
            {
                i = Command.ExecuteScalar();
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return i;
        }
        //-----------------------------------------------------------------------------------
        public DataTable GetData(string command, params object[] parameters)
        {
            string _error;
            if (!TestConnection(out _error))
            {
                throw new Exception("ارتباط با سرور اس کیو ال برقرار نیست" + "\n\n" + _error);
            }
            Command.Parameters.Clear();
            Command.CommandText = command;
            if (parameters != null)
            {
                if (parameters.Length % 2 != 0)
                {
                    throw new Exception("پارامترها نادرست است");
                }
                for (int index = 0; index < parameters.Length; index += 2)
                {
                    Command.Parameters.AddWithValue(parameters[index].ToString().StartsWith("@") ? parameters[index].ToString() : "@" + parameters[index].ToString(), parameters[index + 1]);
                }
            }
            Adapter.SelectCommand = Command;
            System.Data.ConnectionState previousConnectionState = Connection.State;
            DataTable dt = new DataTable();
            try
            {
                Adapter.Fill(dt);
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return dt;
        }
        //----------------------------------------------------------------------------------
        public bool TestConnection(out string error)
        {
            error = "";
            System.Data.ConnectionState previousConnectionState = Connection.State;
            try
            {
                if (((Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
                    Connection.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Connection.Close();
                return false;
            }
            finally
            {
                if ((previousConnectionState == System.Data.ConnectionState.Closed))
                {
                    Connection.Close();
                }
            }
            return true;
        }

        #endregion
    }
}
