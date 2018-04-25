using System;
using System.Collections.Generic;
using System.Text;

namespace DataCodeGenerator
{
    class SqlTypes
    {
        public enum Names
        {
            Int, nvarchar, image, text, uniqueidentifier, tinyint, smallint, smalldatetime, real, money, datetime, Float, sql_variant,
            ntext, bit, Decimal, numeric, smallmoney, bigint, varbinary, varchar, binary, Char, timestamp, nchar, xml, sysname, Time
        }
        public static Type GetType(int field_type, bool is_nullable)
        {
            if (field_type == SqlTypes.Int)
            {
                if (!is_nullable)
                    return (typeof(int));
                else
                    return (typeof(int?));
            }
            else if (field_type == SqlTypes.nvarchar)
            {
                return (typeof(string));
            }
            else if (field_type == SqlTypes.image)
            {
                return (typeof(System.Data.Linq.Binary));
            }
            else if (field_type == SqlTypes.text)
            {
                return (typeof(string));
            }
            else if (field_type == SqlTypes.uniqueidentifier)
            {
                if (!is_nullable)
                    return (typeof(System.Guid));
                else
                    return (typeof(System.Guid?));
            }
            else if (field_type == SqlTypes.tinyint)
            {
                if (!is_nullable)
                    return (typeof(byte));
                else
                    return (typeof(byte?));
            }
            else if (field_type == SqlTypes.smallint)
            {
                if (!is_nullable)
                    return (typeof(System.Int16));
                else
                    return (typeof(System.Int16?));
            }
            else if (field_type == SqlTypes.smalldatetime)
            {
                if (!is_nullable)
                    return (typeof(System.DateTime));
                else
                    return (typeof(System.DateTime?));
            }
            else if (field_type == SqlTypes.real)
            {
                if (!is_nullable)
                    return (typeof(float));
                else
                    return (typeof(float?));
            }
            else if (field_type == SqlTypes.money)
            {
                if (!is_nullable)
                    return (typeof(decimal));
                else
                    return (typeof(decimal?));
            }
            else if (field_type == SqlTypes.datetime)
            {
                if (!is_nullable)
                    return (typeof(System.DateTime));
                else
                    return (typeof(System.DateTime?));
            }
            else if (field_type == SqlTypes.Float)
            {
                if (!is_nullable)
                    return (typeof(double));
                else
                    return (typeof(double?));
            }
            else if (field_type == SqlTypes.sql_variant)
            {
                if (!is_nullable)
                    return (typeof(object));
                else
                    return (typeof(object));
            }
            else if (field_type == SqlTypes.ntext)
            {
                if (!is_nullable)
                    return (typeof(string));
                else
                    return (typeof(string));
            }
            else if (field_type == SqlTypes.bit)
            {
                if (!is_nullable)
                    return (typeof(bool));
                else
                    return (typeof(bool?));
            }
            else if (field_type == SqlTypes.Decimal)
            {
                if (!is_nullable)
                    return (typeof(decimal));
                else
                    return (typeof(decimal?));
            }
            else if (field_type == SqlTypes.numeric)
            {
                if (!is_nullable)
                    return (typeof(int));
                else
                    return (typeof(int?));
            }
            else if (field_type == SqlTypes.smallmoney)
            {
                if (!is_nullable)
                    return (typeof(decimal));
                else
                    return (typeof(decimal?));
            }
            else if (field_type == SqlTypes.bigint)
            {
                if (!is_nullable)
                    return (typeof(long));
                else
                    return (typeof(long?));
            }
            else if (field_type == SqlTypes.varbinary)
            {
                if (!is_nullable)
                    return (typeof(System.Data.Linq.Binary));
                else
                    return (typeof(System.Data.Linq.Binary));
            }
            else if (field_type == SqlTypes.varchar)
            {
                if (!is_nullable)
                    return (typeof(string));
                else
                    return (typeof(string));
            }
            else if (field_type == SqlTypes.binary)
            {
                if (!is_nullable)
                    return (typeof(System.Data.Linq.Binary));
                else
                    return (typeof(System.Data.Linq.Binary));
            }
            else if (field_type == SqlTypes.Char)
            {
                if (!is_nullable)
                    return (typeof(string));
                else
                    return (typeof(string));
            }
            else if (field_type == SqlTypes.timestamp)
            {
                if (!is_nullable)
                    return (typeof(System.DateTime));
                else
                    return (typeof(System.DateTime?));
            }
            else if (field_type == SqlTypes.nchar)
            {
                if (!is_nullable)
                    return (typeof(string));
                else
                    return (typeof(string));
            }
            else if (field_type == SqlTypes.xml)
            {
                if (!is_nullable)
                    return (typeof(string));
                else
                    return (typeof(string));
            }
            else if (field_type == SqlTypes.sysname)
            {
                if (!is_nullable)
                    return (typeof(string));
                else
                    return (typeof(string));
            }
            else if (field_type == SqlTypes.Time)
            {
                if (!is_nullable)
                    return (typeof(TimeSpan));
                else
                    return (typeof(TimeSpan?));
            }
            else if (field_type == 40)
            {
                if (!is_nullable)
                    return (typeof(DateTime));
                else
                    return (typeof(DateTime?));
            }
            else
            {
                return null;
            }
        }
        public static int Int
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "int").ToString());
            }
        }
        public static int nvarchar
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "nvarchar").ToString());
            }
        }
        public static int image
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "image").ToString());
            }
        }
        public static int text
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "text").ToString());
            }
        }
        public static int uniqueidentifier
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "uniqueidentifier").ToString());
            }
        }
        public static int tinyint
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "tinyint").ToString());
            }
        }
        public static int smallint
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "smallint").ToString());
            }
        }
        public static int smalldatetime
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "smalldatetime").ToString());
            }
        }
        public static int real
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "real").ToString());
            }
        }
        public static decimal money
        {
            get
            {
                return decimal.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "money").ToString());
            }
        }
        public static int datetime
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "datetime").ToString());
            }
        }
        public static int Float
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "float").ToString());
            }
        }
        public static int sql_variant
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "sql_variant").ToString());
            }
        }
        public static int ntext
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "ntext").ToString());
            }
        }
        public static int bit
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "bit").ToString());
            }
        }
        public static int Decimal
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "decimal").ToString());
            }
        }
        public static int numeric
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "numeric").ToString());
            }
        }
        public static decimal smallmoney
        {
            get
            {
                return decimal.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "smallmoney").ToString());
            }
        }
        public static int bigint
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "bigint").ToString());
            }
        }
        public static int varbinary
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "varbinary").ToString());
            }
        }
        public static int varchar
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "varchar").ToString());
            }
        }
        public static int binary
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "binary").ToString());
            }
        }
        public static int Char
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "char").ToString());
            }
        }
        public static int timestamp
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "timestamp").ToString());
            }
        }
        public static int nchar
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "nchar").ToString());
            }
        }
        public static int xml
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "xml").ToString());
            }
        }
        public static int sysname
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "sysname").ToString());
            }
        }
        public static int Time
        {
            get
            {
                return int.Parse(DataAccess.Instance.ExecuteScalar("SELECT [xusertype] FROM [sys].[systypes] WHERE [name]=@name", "@name", "time").ToString());
            }
        }
    }
}
