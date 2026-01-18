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
    public class clsLicensesData
    {
        public static bool FindLicense(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT * FROM Licenses
    WHERE LicenseID =@LicenseID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                   
                    ApplicationID = (int)Reader["ApplicationID"];
                    DriverID = (int)Reader["DriverID"];
                    LicenseClass = (int)Reader["LicenseClass"];
                    IssueDate = (DateTime)Reader["IssueDate"];
                    ExpirationDate = (DateTime)Reader["ExpirationDate"];
                   
                    PaidFees = (decimal)Reader["PaidFees"];
                    IsActive = (bool)Reader["IsActive"];
                    IssueReason = (byte)Reader["IssueReason"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];

                    if ( Reader["Notes"]!=DBNull.Value)
                    { Notes = (string)Reader["Notes"]; }
                    else { Notes = ""; }
                        IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }

        public static int GetActiveLicenseIDByPersonID( int PersonID, int LicenseClassID)

        {
            int LicenseID = -1;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                            Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                            Licenses.LicenseClass = @LicenseClass 
                            AND Drivers.PersonID = @PersonID
                            And IsActive=1;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader!=null&&int.TryParse(Reader.ToString(), out int newID))
                {
                    LicenseID = (int)Reader;                    
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); LicenseID = -1; }
            finally { conn.Close(); }
            return LicenseID;
        }

        public static int AddNewLicenses(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Insert Into Licenses
(                             
ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
VALUES(

@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID)
 Select SCOPE_IDENTITY()";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            com.Parameters.AddWithValue("@DriverID", DriverID);
            com.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            com.Parameters.AddWithValue("@IssueDate", IssueDate);
            com.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if(Notes=="")
            { com.Parameters.AddWithValue("@Notes", DBNull.Value); }
            else
                { com.Parameters.AddWithValue("@Notes", Notes); }
            com.Parameters.AddWithValue("@PaidFees", PaidFees);
            com.Parameters.AddWithValue("@IsActive", IsActive);
            com.Parameters.AddWithValue("@IssueReason", IssueReason);
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                con.Open();
                object result = com.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int NewID))
                {
                    ID = NewID;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally { con.Close(); }
            return ID;
        }

        public static bool UpdateLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Update Applications 
                             set
ApplicationID=@ApplicationID,DriverID=@DriverID,LicenseClass=@LicenseClass,IssueDate=@IssueDate,ExpirationDate=@ExpirationDate,Notes=@Notes,PaidFees=@PaidFees,IsActive=@IsActive,IssueReason=@IssueReason,CreatedByUserID=@CreatedByUserID
where LicenseID=@LicenseID";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@LicenseID", LicenseID);
            com.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            com.Parameters.AddWithValue("@DriverID", DriverID);
            com.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            com.Parameters.AddWithValue("@IssueDate", IssueDate);
            com.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if (Notes == "")
            { com.Parameters.AddWithValue("@Notes", DBNull.Value); }
            else
            { com.Parameters.AddWithValue("@Notes", Notes); }
            com.Parameters.AddWithValue("@PaidFees", PaidFees);
            com.Parameters.AddWithValue("@IsActive", IsActive);
            com.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static DataTable GetAllLicenses()

        {
            DataTable Licenses = new DataTable();

            SqlConnection conn = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string Query = @"Select * from Licenses";
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Licenses.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return Licenses;
        }

        public static bool DeleteByLicenseID(int LicenseID)
        {

            bool IsDeleted = false;
            SqlConnection con = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"DELETE FROM Licenses
                            where LicenseID =@LicenseID";
            SqlCommand comm = new SqlCommand(Query, con);
            comm.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static int GetIssueReasonbyApplicationID(int ApplicationID)
        {
            int IssueReason = -1;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @" 
                           Select IssueReason from Licenses
                           where ApplicationID=@AppID";

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@AppID", ApplicationID);


            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null && int.TryParse(Reader.ToString(), out int newID))
                {
                    IssueReason = (int)Reader;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); IssueReason = -1; }
            finally { conn.Close(); }
            return IssueReason;

        }

        public static bool IsLicenseExistByApplicationID(int ApplicationID, int LicenseClassID)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"select Find=1 from Licenses L join Applications A on A.ApplicationID=L.ApplicationID
                              where
                             A.ApplicationID=@ApplicationID and L.LicenseClass=@LicClassID";

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@LicClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null && int.TryParse(Reader.ToString(), out int find))
                {
                    IsFind = find == 1;
                }


            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }


        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"select Find=1 from Licenses L join Applications A on A.ApplicationID=L.ApplicationID
                              where
                             A.ApplicantPersonID=@PersonID and L.LicenseClass=@LicClassID";

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@LicClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader != null && int.TryParse(Reader.ToString(), out int find))
                {
                    IsFind = find == 1;
                }


            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                 Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeactivateLicense(int LicenseID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);

            string query = @"UPDATE Licenses
                           SET 
                              IsActive = 0
                             
                         WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
