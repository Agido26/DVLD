using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    internal class clsCRUD
    {
        public static DataTable RetriveAllData(string Query,string ConnectionString)
        {
            DataTable Data = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Data.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

            return Data;
        }



    }
}
