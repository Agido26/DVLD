using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypesData
    {


        public static DataTable GetAllTestTypes()
        {

            DataTable TestTypes = new DataTable();
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = "Select * from TestTypes";

            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader result = com.ExecuteReader();

                if (result.HasRows)
                {
                    TestTypes.Load(result);

                }

                result.Close();
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); TestTypes = null; }
            finally { con.Close(); }
            return TestTypes;
        }

        public static bool UpdateTestTypes(int ID, string Title, decimal Fees, string Description)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Update TestTypes Set TestTypeTitle=@Title,
                            TestTypeFees=@Fees, TestTypeDescription=@Description  WHERE TestTypeID=@ID";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@ID", ID);
            com.Parameters.AddWithValue("@Title", Title);
            com.Parameters.AddWithValue("@Fees", Fees);
            com.Parameters.AddWithValue("@Description", Description);


            try
            {
                con.Open();
                int result = com.ExecuteNonQuery();
                if (result > 0)
                {
                    Updated = true;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); Updated = false; }
            finally { con.Close(); }
            return Updated;
        }

        public static bool Find(int ID, ref string Title, ref decimal Fees, ref string Description)
        {
            bool IsFind = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Select * from TestTypes  WHERE TestTypeID=@ID";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@ID", ID);


            try
            {
                con.Open();
                SqlDataReader result = com.ExecuteReader();
                if (result.Read())
                {
                    Fees = (decimal)result["TestTypeFees"];
                    Title = (string)result["TestTypeTitle"];
                    Description = (string)result["TestTypeDescription"];
                    IsFind = true;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { con.Close(); }
            return IsFind;
        }
    
    }
}
