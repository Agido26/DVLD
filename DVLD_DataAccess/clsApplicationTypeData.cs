using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {

        public static DataTable GetAllApplicationType()
        {
            DataTable ApplicationType=new DataTable();
            SqlConnection con=new SqlConnection(clsConection.Connectionstring);

            string query = "Select * from ApplicationTypes  ";

            SqlCommand com= new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader result = com.ExecuteReader();

                if (result.HasRows)
                {
                    ApplicationType.Load(result);

                }

                result.Close();
            }

            catch (Exception ex) { Console.WriteLine(ex.Message); ApplicationType= null; }
            finally { con.Close(); }
            return ApplicationType;

        }

        public static bool UpdateApplicationTypes(int ApplicationTypeID, string Title, decimal fees)
        {
            bool Updated = false;

            SqlConnection con= new SqlConnection(clsConection.Connectionstring);

            string query = @"Update ApplicationTypes Set ApplicationTypeTitle=@Title,
                            ApplicationFees=@Fees  WHERE ApplicationTypeID=@ID";

            SqlCommand com=new SqlCommand(query, con);

            com.Parameters.AddWithValue("@ID", ApplicationTypeID);
            com.Parameters.AddWithValue("@Title", Title);
            com.Parameters.AddWithValue("@Fees", fees);

            try 
            {
                con.Open();
                int result= com.ExecuteNonQuery();
                if(result>0)
                {
                    Updated = true;
                }
            
            }
            catch (Exception ex) { Console.WriteLine(ex); Updated = false; }
            finally { con.Close(); }
            return Updated;

        }

        public static bool Find(int ApplicationTypeID, ref string Title, ref decimal fees)
        {
            bool IsFind = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Select * from ApplicationTypes  WHERE ApplicationTypeID=@ID";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@ID", ApplicationTypeID);
            try
            {
                con.Open();
                SqlDataReader result = com.ExecuteReader();
                if (result.Read())
                {
                    fees = (decimal)result["ApplicationFees"];
                    Title= (string)result["ApplicationTypeTitle"];
                    IsFind = true;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { con.Close(); }
            return IsFind;

        }


    }
}
