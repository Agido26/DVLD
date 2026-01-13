using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsPeopleData
    {

        public static DataTable Get_All_People()
        {
            DataTable People= new DataTable();
            SqlConnection conn = new SqlConnection(clsConection.Connectionstring);

            string query = @"SELECT PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
                             CASE
                             WHEN Gendor=0 Then 'Male'
                             ELSE 'Female'
                             END as Gendor
                             ,Address,Phone,Email,c.CountryName
                             from People
                             join Countries c
                             on c.CountryID=People.NationalityCountryID
";
            SqlCommand cmd= new SqlCommand(query, conn);

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

            catch(Exception ex) 
            {
            Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

            return People;
        }


      
        public static bool Update_Person_Infos(int PersonID,string First, string Second, string Third, string Last,
                                      string National_N, DateTime DateOfBirth, byte Gendor,
                                      string phone, string Email, int CountryID, string Address,
                                      string ImagePath)
        {
            bool IsUpdated = false;
            SqlConnection conn=new SqlConnection(clsConection.Connectionstring);
            string query = @"UPDATE People
                             set 
                             NationalNo=@NationalNo,
                             FirstName=@First,SecondName=@Second,ThirdName=@Third,
                             LastName=@Last,DateOfBirth=@DateOfBirth,ImagePath=@ImagePath,Gendor=@Gendor,Address=@Address,
                             NationalityCountryID=@NationalityCountryID,Phone=@Phone,Email=@Email
                             WHERE PersonID=@PersonID";
            SqlCommand comm=new SqlCommand(query, conn);
            comm.Parameters.AddWithValue("@NationalNo", National_N);
            comm.Parameters.AddWithValue("@First", First);
            comm.Parameters.AddWithValue("@Second", Second);
            comm.Parameters.AddWithValue("@Last", Last);
            comm.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            comm.Parameters.AddWithValue("@Gendor", Gendor);
            comm.Parameters.AddWithValue("@Address", Address);
            comm.Parameters.AddWithValue("@Phone", phone);
            comm.Parameters.AddWithValue("@NationalityCountryID", CountryID);
            comm.Parameters.AddWithValue("@PersonID", PersonID);

            if (!string.IsNullOrEmpty(Third) )
            {
                comm.Parameters.AddWithValue("@Third", Third);
            }
            else
                comm.Parameters.AddWithValue("@Third", DBNull.Value);

            if (!string.IsNullOrEmpty(Email))
            {
                comm.Parameters.AddWithValue("@Email", Email);
            }
            else
                comm.Parameters.AddWithValue("@Email", DBNull.Value);

            if (!string.IsNullOrEmpty(ImagePath) )
            {
                comm.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                comm.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            try
            {
                conn.Open();
                int result = comm.ExecuteNonQuery();
                if (result > 0) 
                {
                    IsUpdated = true;
                
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            finally {conn.Close(); }
            return IsUpdated;
        }

        public static int Add_New_People(string First,string Second,string Third,string Last,
                                      string National_N,DateTime DateOfBirth,byte Gendor,
                                      string phone,string Email,int CountryID,string Address,
                                       string ImagePath)
        {
            int IDNumber = -1;
            SqlConnection conn=new SqlConnection(clsConection.Connectionstring);
            string query = @"INSERT INTO People (NationalNo,FirstName,SecondName,ThirdName,LastName,
                            DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)
                            VALUES 
                            (@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,
                            @Gendor,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand com = new SqlCommand(query, conn);

            com.Parameters.AddWithValue("@NationalNo", National_N);
            com.Parameters.AddWithValue("@FirstName", First);
            com.Parameters.AddWithValue("@SecondName", Second);
            com.Parameters.AddWithValue("@LastName", Last);
            com.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            com.Parameters.AddWithValue("@Gendor", Gendor);
            com.Parameters.AddWithValue("@Address", Address);
            com.Parameters.AddWithValue("@Phone", phone);
            com.Parameters.AddWithValue("@NationalityCountryID", CountryID);

            if(!string.IsNullOrEmpty(Third))
            {
                com.Parameters.AddWithValue("@ThirdName", Third);
            }
            else
                com.Parameters.AddWithValue("@ThirdName", DBNull.Value);

            if(!string.IsNullOrEmpty(Email))
            {
                com.Parameters.AddWithValue("@Email", Email);
            }
            else 
                com.Parameters.AddWithValue("@Email", DBNull.Value);

            if(!string.IsNullOrEmpty(ImagePath))
            {
                com.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                com.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try 
            {
                conn.Open();
                object result = com.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(),out int NewID))
                {
                    IDNumber = NewID;
                }
            
            }
            catch(Exception ex) { Console.WriteLine(ex); IDNumber= -1; }
            finally { conn.Close(); }

            return IDNumber;



        }

       public static bool Find_Person_By_ID(int PersonID,ref string First, ref string Second,ref string Third, ref string Last,
                                      ref string National_N,ref DateTime DateOfBirth,ref byte Gendor,
                                      ref string phone,ref string Email,ref int CountryID,ref string Address,
                                      ref string ImagePath)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT * FROM People
                             WHERE PersonID =@PersonID";

            SqlCommand comm= new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@PersonID", PersonID);

            try 
            {
                connection.Open();
                SqlDataReader Reader= comm.ExecuteReader();
                if (Reader.Read())
                {
                    First = (string)Reader["FirstName"];

                    Second= (string)Reader["SecondName"];

                    if (Reader["ThirdName"] == DBNull.Value)
                    { Third = null; }
                    else
                        Third = (string)Reader["ThirdName"];

                    Last = (string)Reader["LastName"];

                    National_N= (string)Reader["NationalNo"];

                    DateOfBirth= (DateTime)Reader["DateOfBirth"];

                    Gendor= (byte)Reader["Gendor"];

                    Address= (string)Reader["Address"];

                    phone= (string)Reader["Phone"];

                    if (Reader["Email"]== DBNull.Value)
                        Email = null;
                    else
                        Email = (string)Reader["Email"];

                    CountryID= (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"]==DBNull.Value)
                        ImagePath = null;
                    else
                        ImagePath = (string)Reader["ImagePath"];

                    IsFind = true;

                }
                Reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;

        }


        public static bool Find_Person_By_NationalNo(string National_N, ref int PersonID, ref string First, ref string Second, ref string Third, ref string Last,
                                     ref DateTime DateOfBirth, ref byte Gendor,
                                    ref string phone, ref string Email, ref int CountryID, ref string Address,
                                    ref string ImagePath)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"SELECT * FROM People
                             WHERE NationalNo =@NationalNo";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@NationalNo", National_N);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    First = (string)Reader["FirstName"];

                    Second = (string)Reader["SecondName"];

                    if (Reader["ThirdName"] == DBNull.Value)
                    { Third = null; }
                    else
                        Third = (string)Reader["ThirdName"];

                    Last = (string)Reader["LastName"];

                    PersonID = (int)Reader["PersonID"];

                    DateOfBirth = (DateTime)Reader["DateOfBirth"];

                    Gendor = (byte)Reader["Gendor"];

                    Address = (string)Reader["Address"];

                    phone = (string)Reader["Phone"];

                    if (Reader["Email"] == DBNull.Value)
                        Email = null;
                    else
                        Email = (string)Reader["Email"];

                    CountryID = (int)Reader["NationalityCountryID"];

                    if (Reader["ImagePath"] == DBNull.Value)
                        ImagePath = null;
                    else
                        ImagePath = (string)Reader["ImagePath"];

                    IsFind = true;

                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;

        }



        public static bool Delete_Person_BY_ID(int PersonID)
        {
            bool IsDeleted = false;
            SqlConnection con = new SqlConnection( clsConection.Connectionstring);
            string Query = @"DELETE FROM People
                            where PersonID =@PersonID";

            SqlCommand comm= new SqlCommand(Query, con);
            comm.Parameters.AddWithValue("@PersonID", PersonID);

            try 
            {
                con.Open();
                object Result= comm.ExecuteNonQuery();
                if((int)Result>0)
                {
                    IsDeleted = true;
                }
            }
            catch(Exception ex) { Console.WriteLine (ex); IsDeleted = false; }
            finally { con.Close(); }
            return IsDeleted;



        }

    }
}
