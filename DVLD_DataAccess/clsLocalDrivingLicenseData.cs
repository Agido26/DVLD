using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseData
    {

        public static DataTable GetAllLocalDrivingLicense()
        {
            return clsCRUD.RetriveAllData("Select * from LocalDrivingLicenseApplications_View", clsConection.Connectionstring);
        }
       
        public static bool FindByLocalLicenseID(int ID,ref int ApplicationID,ref int LicClassID )
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"Select * from LocalDrivingLicenseApplications
                             where LocalDrivingLicenseApplicationID =@ID";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicClassID = (int)Reader["LicenseClassID"];
                   
                    IsFind = true;
                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;
        }


        public static bool FindByApplicationID( int ApplicationID,ref int LocalLicenseID, ref int LicClassID)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"Select * from LocalDrivingLicenseApplications
                             where ApplicationID =@ID";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@ID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    LocalLicenseID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicClassID = (int)Reader["LicenseClassID"];

                    IsFind = true;
                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;
        }

        public static int AddNewLocalDrivingLicenseApplication(int LicenseClassID, int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Insert Into LocalDrivingLicenseApplications(ApplicationID, LicenseClassID)
                             Values(@ApplicationID,@LicenseClassID)
                              Select SCOPE_IDENTITY()";

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            com.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                con.Open();
                object result = com.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int NewID))
                {
                    LocalDrivingLicenseApplicationID = NewID;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); return LocalDrivingLicenseApplicationID; }
            finally { con.Close(); }
            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Update Applications 
                             set
ApplicationID=@ApplicationID,LicenseClassID=@LicenseClassID
where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            com.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            com.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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


       
        public static int PassedTestCount(int LocalDrivingLicenseApplicationID)

        {
            int PassTests = 0;

            SqlConnection conn = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT PassedTestCount FROM LocalDrivingLicenseApplications_View
    WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                   
                    PassTests = (int)Reader["PassedTestCount"];
                   
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { conn.Close(); }
            return PassTests;
        }



        public static bool DeleteByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {

            bool IsDeleted = false;
            SqlConnection con = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"DELETE FROM LocalDrivingLicenseApplications
                            where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";
            SqlCommand comm = new SqlCommand(Query, con);
            comm.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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


        public static bool DoesPassTestType(int LocalDrivingLicenseID, int TestType)

        {
            bool IsPassed = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"
                             Select top 1 T.TestResult from LocalDrivingLicenseApplications L 
                             join TestAppointments TP on L.LocalDrivingLicenseApplicationID=TP.LocalDrivingLicenseApplicationID 
                             join  Tests T  on T.TestAppointmentID=TP.TestAppointmentID
                             where TP.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TP.TestTypeID=@TestTypedID
                             order by TP.TestAppointmentID Desc
                             ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypedID", TestType);
            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null)
                {
                    IsPassed = (bool)Reader;
                }


            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { conn.Close(); }
            return IsPassed;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseID, int TestType)

        {
            bool IsAttend = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"
                             SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc
                             ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestType);
            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null)
                {
                    IsAttend = true;
                }


            }
            catch (Exception ex) { Console.WriteLine(ex);  }
            finally { conn.Close(); }
            return IsAttend;
        }

        public static int TotalTrailPerTest(int LocalDrivingLicenseID, int TestTypeID)
        {

            int Trails = 0;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            
            string Query = @"Select  TotalTrailPerTest=count(T.TestID) from LocalDrivingLicenseApplications L 
                             join TestAppointments TP on L.LocalDrivingLicenseApplicationID=TP.LocalDrivingLicenseApplicationID 
                             join  Tests T  on T.TestAppointmentID=TP.TestAppointmentID
                             where TP.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TP.TestTypeID=@TestTypeID";
           
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null && int.TryParse(Reader.ToString(), out int result))
                {
                    Trails = result;
                }


            }
            catch (Exception ex) { Console.WriteLine(ex);  }
            finally { conn.Close(); }
            return Trails;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalLisenceID, int TestTypeID)
        {

            bool Find = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @" 
                             Select top 1 found=1 from  LocalDrivingLicenseApplications L join 
                             TestAppointments TP  on L.LocalDrivingLicenseApplicationID=TP.LocalDrivingLicenseApplicationID 
                             where TP.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TP.TestTypeID=@TestTypeID and TP.IsLocked=0
                              ORDER BY TP.TestAppointmentID desc";
            
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLisenceID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null)
                {
                    Find = true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); Find = false; }
            finally { conn.Close(); }
            return Find;
        }


    }
}
