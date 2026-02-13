using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDriver
    {
        enum enMode { Add=1, Update=2}
        enMode Mode= enMode.Add;
        public int DriverID {  get; set; }
        public int PersonID {  get; set; }
        public clsPeople PersonInfo { get; set; }
        public int CreatedByUserID {  get; set; }
        public clsUser CreatedUserInfo { get; set; }
        public DateTime CreateDate { get; set; }
        
        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreateDate=DateTime.Now;
            Mode= enMode.Add;
        }
      
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreateDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.PersonInfo=clsPeople.Find(PersonID);
            this.CreatedByUserID=CreatedByUserID;
            this.CreatedUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.CreateDate=CreateDate;
            Mode= enMode.Update;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }
        public static clsDriver Find(int DriverID)
        {
            int PersonID=-1,CreatedByUserID=-1;
            DateTime CreateDate=DateTime.Now;

            if(clsDriversData.FindDrivers(DriverID,ref PersonID,ref CreatedByUserID,ref CreateDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreateDate);
            }
            return null;
        }

        public static clsDriver FindDriverByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreateDate = DateTime.Now;

            if (clsDriversData.FindDriversByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreateDate))
            {
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreateDate);
            }
            return null;
        }

        private bool _Update()
        {
            return clsDriversData.UpdateDrivers(DriverID,PersonID,CreatedByUserID,CreateDate);
        }

        private bool _AddDriver()
        {
            this.DriverID  = clsDriversData.AddNewDriver(PersonID, CreatedByUserID);
            return this.DriverID != -1 ;
        }


        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    if (_AddDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }


        public static bool Delete(int DriverID)
        {
            return clsDriversData.DeleteByDriverID(DriverID);
        }

        public static bool IsDriverExist(int DriverID)
        {
            return clsDriversData.IsDriverExist(DriverID);
        }

        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicensesData.GetDriverLicenses(DriverID);
        }
        public static DataTable GetInternationalLicneses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }

    }
}
