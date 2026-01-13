using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountriesData
    {
        public static DataTable Get_All_Countries()
        {
            DataTable Countries = new DataTable();
            SqlConnection conn = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT * from Countries order by CountryName";
            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Countries.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return Countries;

        }

        public static bool Find_Country_By_ID(int CountryID, ref string Name)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT * FROM Countries
                             WHERE CountryID =@CountryID";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    Name = (string)Reader["CountryName"];
                    IsFind = true;
                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;

        }

        public static bool Find_Country_By_Name(string Name,ref int CountryID )
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT * FROM Countries
                             WHERE CountryName =@Name";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    CountryID = (int)Reader["CountryID"];
                    IsFind = true;
                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;

        }





    }
}
