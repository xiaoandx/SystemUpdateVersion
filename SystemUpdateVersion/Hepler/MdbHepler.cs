using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUpdateVersion.Hepler
{
    public class MdbHepler
    {
        public static string DBCon = ConfigurationManager.AppSettings["DBCon"];

        public static OleDbConnection Connection(string strConn)
        {
            string con = strConn.Replace("\\\\", "\\");
            OleDbConnection schema = new OleDbConnection(con);
            return schema;
        }

        public static DataTable Query(string sql) {
            DataTable data = new DataTable();
            OleDbConnection conn = Connection(DBCon);
            OleDbDataAdapter dbDataAdapter = null;
            try
            {
                conn.Open();
                dbDataAdapter = new OleDbDataAdapter(sql, conn);
                dbDataAdapter.Fill(data);
            }
            catch (Exception ex)
            {
                throw new Exception("DB Exception Message:" + ex.Message);
            }
            finally
            {
                dbDataAdapter.Dispose();
                conn.Close();
            }
            return data;
        }


        public static int Update(string sql)
        {
            int _UpdateStatus = 0;
            OleDbConnection conn = Connection(DBCon);
            OleDbCommand dbCommand = null;
            try
            {
                conn.Open();
                dbCommand = new OleDbCommand(sql, conn);
                _UpdateStatus = dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("DB Exception Message:" + ex.Message);
            }
            finally
            {
                dbCommand.Dispose();
                conn.Close();
            }
            return _UpdateStatus;
        }
    }
}
