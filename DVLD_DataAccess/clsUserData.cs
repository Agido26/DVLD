using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUserData
    {

        public static bool FindUser(string UserName, string Password,
                                     ref bool IsActive, ref int UserID, ref int PersonID)
        {
            bool IsFind = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Select * from Users
                             where Users.UserName=@UserName and Users.Password=@Password";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsActive = (bool)reader["IsActive"];
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsFind = true;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); IsFind = false; }
            finally { con.Close(); }
            return IsFind;

        }

        public static bool FindUserByPersonID(int PersonID, ref string UserName, ref string Password,
                                   ref bool IsActive, ref int UserID)
        {
            bool IsFind = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Select * from Users
                             where Users.PersonID=@PersonID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = (bool)reader["IsActive"];
                    UserID = (int)reader["UserID"];
                    IsFind = true;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); IsFind = false; }
            finally { con.Close(); }
            return IsFind;

        }

        public static DataTable GetAllUsers()
        {
            DataTable People = new DataTable();
            SqlConnection conn = new SqlConnection(clsConection.Connectionstring);

            string query = @"Select Users.UserID,Users.PersonID , FullName=p.FirstName+' '+ p.SecondName+' '+p.ThirdName+' '+p.LastName ,Users.UserName,Users.IsActive
                             from people p
                             join  Users   on Users.PersonID=p.PersonID";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    People.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

            return People;
        }

        public static int AddNewUser(int PersonID, string username, string password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Insert Into Users (PersonID,UserName,Password,IsActive)
                             Values
                             (@PersonID,@Username,@Password,@IsActive)
                               SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int NewID))
                {
                    UserID = NewID;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); UserID = -1; }
            finally { con.Close(); }

            return UserID;
        }

        public static bool UpdateUserInfo(int UserID, string Username, string Password, bool IsActive)
        {
            bool Updated = false;
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);
            string query = @"Update Users 
                            Set UserName=@Username,Password=@Password,IsActive=@IsActive
                            where UserID=@UserID";

            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@UserID", UserID);
            comm.Parameters.AddWithValue("@Username", Username);
            comm.Parameters.AddWithValue("@Password", Password);
            comm.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                con.Open();
                int result = comm.ExecuteNonQuery();
                if(result>0)
                {
                    Updated = true;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex);Updated = false; }
            finally { con.Close(); }
            return Updated;
        }

        public static bool DeleteUser(int UserID) 
        {
            bool Detelted = false;
            SqlConnection con = new SqlConnection(clsConection.Connectionstring);
            string query = @"Delete From Users
                            where UserID=@UserID";

            SqlCommand comm = new SqlCommand(query, con);
            comm.Parameters.AddWithValue("@UserID", UserID);
            
            try
            {
                con.Open();
                int result = comm.ExecuteNonQuery();
                if (result > 0)
                {
                    Detelted = true;
                }

            }
            catch (Exception ex) { Console.WriteLine(ex); Detelted = false; }
            finally { con.Close(); }
            return Detelted;
        }

        public static bool FindUserByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password,
                                    ref bool IsActive)
        {
            bool IsFind = false;

            SqlConnection con = new SqlConnection(clsConection.Connectionstring);

            string query = @"Select * from Users
                             where Users.UserID=@UserID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = (bool)reader["IsActive"];
                    PersonID = (int)reader["PersonID"];
                    IsFind = true;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); IsFind = false; }
            finally { con.Close(); }
            return IsFind;

        }

    }
}
