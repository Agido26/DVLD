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
    public class clsTestAppointmentsData
    {

        public static DataTable GetAllTestAppointments()

        {
            DataTable TestAppointments = new DataTable();

            SqlConnection conn = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string Query = @"Select * from TestAppointments";
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    TestAppointments.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return TestAppointments;
        }

        public static bool FindTestAppointment(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT * FROM TestAppointments
    WHERE TestAppointmentID =@TestAppointmentID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    TestTypeID = (int)Reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)Reader["AppointmentDate"];
                    PaidFees = (decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsLocked = (bool)Reader["IsLocked"];
                   
                    if (Reader["RetakeTestApplicationID"] != DBNull.Value)
                    { RetakeTestApplicationID = (int)Reader["RetakeTestApplicationID"]; }
                   
                    else
                    { RetakeTestApplicationID = -1; }

                    IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }



        public static int AddNewTestAppointments(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Insert Into TestAppointments
(                             
TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID)
VALUES(

@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID)
 Select SCOPE_IDENTITY()";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            com.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            com.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            com.Parameters.AddWithValue("@PaidFees", PaidFees);
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            com.Parameters.AddWithValue("@IsLocked", IsLocked);
            if(RetakeTestApplicationID!=-1)
            { com.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID); }
           else
            { com.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value); }


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

      

        public static bool DeleteByTestAppointmentID(int TestAppointmentID)
        {

            bool IsDeleted = false;
            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"DELETE FROM TestAppointments
                            where TestAppointmentID =@TestAppointmentID";
            SqlCommand comm = new SqlCommand(Query, conn);
            comm.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                conn.Open();
                object Result = comm.ExecuteNonQuery();
                if ((int)Result > 0)
                {
                    IsDeleted = true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); IsDeleted = false; }
            finally { conn.Close(); }
            return IsDeleted;

        }


        public static bool UpdateTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Update TestAppointments 
                             set
TestTypeID=@TestTypeID,LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,AppointmentDate=@AppointmentDate,PaidFees=@PaidFees,CreatedByUserID=@CreatedByUserID,IsLocked=@IsLocked,RetakeTestApplicationID=@RetakeTestApplicationID
where TestAppointmentID=@TestAppointmentID";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            com.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            com.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            com.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            com.Parameters.AddWithValue("@PaidFees", PaidFees);
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            com.Parameters.AddWithValue("@IsLocked", IsLocked);
            if (RetakeTestApplicationID != -1)
            { com.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID); }
            else { com.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value); }
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

        public static bool IsThereActiveAppointmentByLocalLicenseID(int LocalDrivingLicenseID, int TestTypeID)
        {

            bool Find =false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"select find=1 from TestAppointments 
                             where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TestTypeID=@TestTypeID and IsLocked=0 ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null)
                {
                    Find = (bool)Reader;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); Find = false; }
            finally { conn.Close(); }
            return Find;
        }

        public static bool IsThereAppointmentByLocalLicenseID(int LocalDrivingLicenseID, int TestTypeID)
        {

            bool Find = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"select find=1 from TestAppointments 
                             where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TestTypeID=@TestTypeID ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null)
                {
                    Find = (bool)Reader;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); Find = false; }
            finally { conn.Close(); }
            return Find;
        }
        public static int CountTrails(int LocalDrivingLicenseID, int TestTypeID)
        {

            int Trails = 0;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"Select  count(TestAppointmentID) from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TestTypeID=@TestTypeID and IsLocked =1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader!=null && int.TryParse(Reader.ToString(),out int result))
                {
                    Trails = result;
                }


            }
            catch (Exception ex) { Console.WriteLine(ex); Trails = -1; }
            finally { conn.Close(); }
            return Trails;
        }

        public static DataTable GetAllTestAppointmentsByLocalID(int LocalLicenseID, int TestTypeID)

        {
            DataTable Data = new DataTable();

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees,IsLocked FROM TestAppointments
    WHERE LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
                {
                    Data.Load(Reader);
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { conn.Close(); }
            return Data;
        }

    }
}
