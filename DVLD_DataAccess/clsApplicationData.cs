using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {

        public static DataTable GetAllApplications()
        {
            DataTable Applications = new DataTable();
            SqlConnection conn = new SqlConnection(clsConection.Connectionstring);
            string Query = @"Select * from Applications";
            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Applications.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return Applications;
        }

        public static int AddNewApplication(int PersonID,DateTime Date,int ApplicationTypeID,
                                             int Status,DateTime LastStatusDate,decimal PaidFees,int UserID)
        {
            int ApplicationID = -1;
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Insert Into Applications(ApplicantPersonID,ApplicationDate,
                             ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,
                             CreatedByUserID)
                             Values(@PersonID,@ADate,@ApplicationTypeID,@Status,@lDate,@PaidFees,@UserID)
                              Select SCOPE_IDENTITY()";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@PersonID",PersonID);
            com.Parameters.AddWithValue("@ADate", Date);
            com.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            com.Parameters.AddWithValue("@Status", Status);
            com.Parameters.AddWithValue("@lDate", LastStatusDate);
            com.Parameters.AddWithValue("@PaidFees", PaidFees);
            com.Parameters.AddWithValue("@UserID", UserID);

            try 
            {
                con.Open();
                object result = com.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int NewID))
                {
                    ApplicationID = NewID;
                }

            }
            catch(Exception ex) { Console.WriteLine(ex); return ApplicationID; }
            finally { con.Close(); }
            return ApplicationID;
        }

        public static bool DeletApplication(int ApplicationID)
        {

            bool IsDeleted = false;
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);
            string Query = @"DELETE FROM Applications
                            where ApplicationID =@ApplicationID";

            SqlCommand comm = new SqlCommand(Query, con);
            comm.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                con.Open();
                object Result = comm.ExecuteNonQuery();
                if ((int)Result > 0)
                {
                    IsDeleted = true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); IsDeleted = false; }
            finally { con.Close(); }
            return IsDeleted;

        }


        public static bool UpdateApplication(int ApplicationID,byte AppStatus,DateTime LastStatusDate,decimal PaidFees,int UserID)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Update Applications 
                             set
                             ApplicationStatus=@AppStatus ,LastStatusDate=@LastStatusDate ,PaidFees=@PaidFees,CreatedByUserID=@UserID    
                             where ApplicationID=@AppID
                             ";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@AppID", ApplicationID);
            com.Parameters.AddWithValue("@AppStatus", AppStatus);
            com.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            com.Parameters.AddWithValue("@PaidFees", PaidFees);
            com.Parameters.AddWithValue("@UserID", UserID);


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

        public static bool FindApplicationByID(int ApplicationID,ref int PersonID,ref DateTime ApplicantDate,
                                               ref int TypeID,ref byte Status,ref DateTime lastStatusDate,
                                              ref decimal PaidFees,ref int UserID)
        {
           
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT * FROM Applications
                             WHERE ApplicationID =@ApplicationID";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    PersonID = (int)Reader["ApplicantPersonID"];
                    ApplicantDate = (DateTime)Reader["ApplicationDate"];
                    TypeID = (int)Reader["ApplicationTypeID"];
                    Status = (byte)Reader["ApplicationStatus"];
                    lastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    UserID = (int)Reader["CreatedByUserID"];

                    IsFind = true;
                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;


        }

        public static int GetActiveApplicationID(int PersonID,  int ApplicationTypeID)
        {
            int Id = -1;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"
                             Select ActiveApplicatoinID=ApplicationID from Applications
                             where ApplicantPersonID=@PersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1
";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@PersonID", PersonID);
            comm.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            
            try
            {
                connection.Open();
                object Reader = comm.ExecuteScalar();
                if (Reader!=null && int.TryParse(Reader.ToString(),out int newid))
                {
                    Id = newid;
                }
               
            }
            catch (Exception ex) { Console.WriteLine(ex); Id = -1; }
            finally { connection.Close(); }
            return Id;
        }



        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID, int ApplicationTypeID)
        {
            int Id = -1;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"Select L.* from Applications A
                             join LocalDrivingLicenseApplications L on A.ApplicationID=L.ApplicationID 
                             join LicenseClasses C on C.LicenseClassID=L.LicenseClassID
                             
                             where A.ApplicantPersonID=@PersonID and L.LicenseClassID=@LicenseClassID and A.ApplicationTypeID=@ApplicationTypeID and A.ApplicationStatus=1 ";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@PersonID", PersonID);
            comm.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            comm.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
           


            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {

                    Id = (int)Reader["ApplicationID"];
                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); Id = -1; }
            finally { connection.Close(); }
            return Id;
        }



        public static bool UpdateStatus(int ApplicationID, byte AppStatus, DateTime LastStatusDate)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Update Applications 
                             set
                             ApplicationStatus=@AppStatus ,LastStatusDate=@LastStatusDate   
                             where ApplicationID=@AppID
                             ";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@AppID", ApplicationID);
            com.Parameters.AddWithValue("@AppStatus", AppStatus);
            com.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            

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


    }
}
