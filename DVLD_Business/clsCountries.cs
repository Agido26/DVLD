using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsCountries
    {


        public string Name { get; set; }
        public int ID { get; set; }


        public clsCountries()
        {
            Name = "";
            ID = -1;

        }

        private clsCountries(int ID, string name)
        {
            Name = name;
            this.ID = ID;
        }

        public static clsCountries Find(int id)
        {
            string Name = "";
            if (clsCountriesData.Find_Country_By_ID(id, ref Name))
            {
                return new clsCountries(id, Name);
            }
            return null;
        }
        public static clsCountries Find(string Name)
        {
            int ID = -1;
            if (clsCountriesData.Find_Country_By_Name(Name, ref ID))
            {
                return new clsCountries(ID, Name);
            }
            return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesData.Get_All_Countries();
        }
    }
}