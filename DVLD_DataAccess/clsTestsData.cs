using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestsData
    {
        public static DataTable GetAllTests()

        {
            DataTable Tests = new DataTable();

            SqlConnection conn = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string Query = @"Select * from Tests";
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Tests.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return Tests;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Update Tests 
                             set
TestAppointmentID=@TestAppointmentID,TestResult=@TestResult,Notes=@Notes,CreatedByUserID=@CreatedByUserID
where TestID=@TestID";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@TestID", TestID);
            com.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            com.Parameters.AddWithValue("@TestResult", TestResult);
            if(Notes!="")
            { com.Parameters.AddWithValue("@Notes", Notes); }
            else { com.Parameters.AddWithValue("@Notes", DBNull.Value); }
                com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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


        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Insert Into Tests
                              (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                              VALUES(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID)
                              Update TestAppointments Set IsLocked=1 where TestAppointmentID=@TestAppointmentID 
                               Select SCOPE_IDENTITY()";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            com.Parameters.AddWithValue("@TestResult", TestResult);
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            if (Notes!="")
            { com.Parameters.AddWithValue("@Notes", Notes); }
            else { com.Parameters.AddWithValue("@Notes", DBNull.Value); }
         

            try
            {
                con.Open();
                object result = com.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int NewID))
                {
                    ID = NewID;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); return ID; }
            finally { con.Close(); }
            return ID;
        }

        public static bool DeleteByTestID(int TestID)
        {

            bool IsDeleted = false;
            SqlConnection con = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"DELETE FROM Tests
                            where TestID =@TestID";
            SqlCommand comm = new SqlCommand(Query, con);
            comm.Parameters.AddWithValue("@TestID", TestID);

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


        public static bool FindTests(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT * FROM Tests
    WHERE TestID =@TestID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (bool)Reader["TestResult"];

                    if( Reader["Notes"]!=DBNull.Value)
                   { Notes = (string)Reader["Notes"]; }
                    else { Notes = ""; }
                        CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }

        public static bool FindTestByAppointmentID(int TestAppointmentID, ref int TestID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT * FROM Tests
    WHERE TestAppointmentID =@TestAppointmentID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    TestID = (int)Reader["TestID"];
                    TestResult = (bool)Reader["TestResult"];
                    if (Reader["Notes"] != DBNull.Value)
                    { Notes = (string)Reader["Notes"]; }
                    else { Notes = ""; }
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }

        public static bool TestResultByTestID(int TestID, int TestType)

        {
            bool IsPassed = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"Select TestResult from Tests T
                             join TestAppointments TA on TA.TestAppointmentID=T.TestAppointmentID
                             where TA.TestID=@TestID and TA.TestTypeID=@TestTypedID
                             ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestID", TestID);
            cmd.Parameters.AddWithValue("@TestTypedID", TestType);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    IsPassed = (bool)Reader["TestResult"];
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsPassed = false; }
            finally { conn.Close(); }
            return IsPassed;
        }

        public static bool TestResultByTestAppointmentsID(int TestAppointmentID,int TestType)

        {
            bool IsPassed = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"Select T.TestResult from Tests T
                             join TestAppointments TA on TA.TestAppointmentID=T.TestAppointmentID
                             where TA.TestAppointmentID=@TestAppointmentID and TA.TestTypeID=@TestTypedID
                             ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestTypedID", TestType);
            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader!=null)
                {
                    IsPassed =(bool)Reader;
                }
               
            }
            catch (Exception ex) { Console.WriteLine(ex); IsPassed = false; }
            finally { conn.Close(); }
            return IsPassed;
        }

        public static bool TestResultByLocalDrivingLicenseID(int LocalDrivingLicenseID, int TestType)

        {
            bool IsPassed = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"Select TestResult from Tests T join TestAppointments TP on T.TestAppointmentID=TP.TestAppointmentID
                             where TP.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TP.TestTypeID=@TestTypedID and T.TestResult=1
                             ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypedID", TestType);
            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader!=null)
                {
                    IsPassed = (bool)Reader;
                }
               

            }
            catch (Exception ex) { Console.WriteLine(ex); IsPassed = false; }
            finally { conn.Close(); }
            return IsPassed;
        }

        public static bool UpdateTestResult(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Update Tests 
                             set
                             TestAppointmentID=@TestAppointmentID,TestResult=@TestResult,
                             Notes=@Notes,CreatedByUserID=@CreatedByUserID
                             where TestID=@TestID";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@TestID", TestID);
            com.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            com.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != "")
            { com.Parameters.AddWithValue("@Notes", Notes); }
            else { com.Parameters.AddWithValue("@Notes", DBNull.Value); }
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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

        public static bool GetLastTestPerPersonAndTestTypeAndLicenseClass(int PersonID,int LicClassID,int TestType,ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
           
            string Query = @" SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                         Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicClassID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestType);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    TestID = (int)Reader["TestID"];
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (bool)Reader["TestResult"];

                    if (Reader["Notes"]!=DBNull.Value)
                    { Notes = (string)Reader["Notes"]; }
                    else { Notes = ""; }
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }

        public static int GetPassedTestCount(int LocalLiceseID)
        {
            int PassedTest = 0;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");

            string Query = @" Select PassedTestCount = count(TestTypeID) from Tests T 
                              join TestAppointments TP on TP.TestAppointmentID=T.TestAppointmentID
                              where TP.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLiceseID);
            
            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader!=null)
                {
                    PassedTest = (int)Reader;
                }
               

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { conn.Close(); }
            return PassedTest;
        }


    }
}
