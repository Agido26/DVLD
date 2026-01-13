using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLincesClassesData
    {

        public static DataTable GetAllLinceseClasses()
        {
            DataTable LinceseClasses = new DataTable();
            SqlConnection conn = new SqlConnection(clsConection.Connectionstring);
            string Query = @"Select * from LicenseClasses";
            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    LinceseClasses.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { conn.Close(); }
            return LinceseClasses;

        }

        public static bool FindLicenseClassByID(int LicenseClassID,ref string ClassName,ref string ClassDiscription,ref byte MinAllowAge,ref byte DefaultValidtyLength,ref decimal ClassFees)
        {
            bool IsFind = false;
            SqlConnection connection = new SqlConnection(clsConection.Connectionstring);
            string Query = @"Select * from LicenseClasses
                             where LicenseClassID=@LicenseClassID";

            SqlCommand comm = new SqlCommand(Query, connection);

            comm.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader Reader = comm.ExecuteReader();
                if (Reader.Read())
                {
                    ClassName = (string)Reader["ClassName"];
                    ClassDiscription = (string)Reader["ClassDescription"];
                    MinAllowAge = (byte)Reader["MinimumAllowedAge"];
                    DefaultValidtyLength = (byte)Reader["DefaultValidityLength"];
                    ClassFees =(decimal)Reader["ClassFees"];

                    IsFind = true;

                }
                Reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex); IsFind = false; }
            finally { connection.Close(); }
            return IsFind;

        }

        
    }
}
