using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriversData
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Insert Into Drivers
                             (PersonID, CreatedByUserID, CreatedDate)
                             VALUES
                             (@PersonID, @CreatedByUserID, @CreatedDate)
                              Select SCOPE_IDENTITY()";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@PersonID", PersonID);
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            com.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
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

        public static bool UpdateDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            bool Updated = false;

            SqlConnection con = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string query = @"Update Drivers 
                             set
                             PersonID=@PersonID,CreatedByUserID=@CreatedByUserID,CreatedDate=@CreatedDate
                             where DriverID=@DriverID";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@DriverID", DriverID);
            com.Parameters.AddWithValue("@PersonID", PersonID);
            com.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            com.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                con.Open();
                int result = com.ExecuteNonQuery();
                Updated = result > 0;
            }
            catch (Exception ex) { Console.WriteLine(ex); Updated = false; }
            finally { con.Close(); }
            return Updated;
        }

        public static bool DeleteByDriverID(int DriverID)
        {

            bool IsDeleted = false;
            SqlConnection con = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"DELETE FROM Drivers
                            where DriverID =@DriverID";
            SqlCommand comm = new SqlCommand(Query, con);
            comm.Parameters.AddWithValue("@DriverID", DriverID);

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

        public static DataTable GetAllDrivers()

        {
            DataTable Drivers = new DataTable();

            SqlConnection conn = new SqlConnection("Server=.;DataBase=DVLD; User Id=sa;Password=123456");
            string Query = @"Select * from Drivers_View";
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Drivers.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return Drivers;
        }

        public static bool FindDrivers(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT * FROM Drivers
                             WHERE DriverID =@DriverID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    PersonID = (int)Reader["PersonID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                    IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }


        public static bool FindDriversByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)

        {
            bool IsFind = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT * FROM Drivers
                             WHERE PersonID =@PersonID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    DriverID = (int)Reader["DriverID"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    CreatedDate = (DateTime)Reader["CreatedDate"];
                    IsFind = true;
                }
                Reader.Close();

            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { conn.Close(); }
            return IsFind;
        }

        public static bool IsDriverExist( int PersonID)

        {
            bool IsExist = false;

            SqlConnection conn = new SqlConnection(" Server=.;DataBase=DVLD; User Id=sa;Password=123456 ");
            string Query = @"SELECT find=1 FROM Drivers
                             WHERE PersonID =@PersonID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                conn.Open();
                object Reader = cmd.ExecuteScalar();
                if (Reader!=null)
                {       
                    IsExist = true;
                }
               

            }
            catch (Exception ex) { Console.WriteLine(ex);  }
            finally { conn.Close(); }
            return IsExist;
        }


    }
}
