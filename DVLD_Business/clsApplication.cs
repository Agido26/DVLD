using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplication
    {
       public enum enMode {New=1, Update=2}
     public   enMode Mode;
        public enum enStatus { enNew=1,enCancelled=2,enCompleted=3}
        public enum enApplicationType
        {
            NewLocalDrivingLicense = 1, RenewLocalLicense = 2,
            ReplacementForLost = 3, ReplacementForDamged = 4,
            ReleaseDetained = 5, InternationalLicense = 6, RetakeTest = 7
        }


        public int ApplicationID { get; set; }
        public int PersonID {  get; set; }
        public clsPeople Person{ get; set; }
        public int UserID {  get; set; }
        public clsUser User{ get; set; }
        public DateTime ApplicationDate {  get; set; }
        public int ApplicationTypeID {  get; set; }
        public clsApplicationType ApplicationType { get; set; }
        public enStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate {  get; set; }
        public decimal PaidFees {  get; set; }

      public  clsApplication()
        {
            ApplicationID = -1;
            PersonID = -1;
            UserID = -1;
            ApplicationStatus = 0;
            LastStatusDate = DateTime.Now;
            ApplicationDate = DateTime.Now;
            PaidFees = -1;
            ApplicationTypeID = -1;
            Mode = enMode.New;
        }

        clsApplication(int ApplicationID,int PersonID,int UserID, clsApplication.enStatus ApplicationStatus,DateTime LastStatusDate
                        ,DateTime ApplicationDate,decimal PaidFees,int ApplicationTypeID)
        {
           this. ApplicationID = ApplicationID;
            this.PersonID = PersonID;
            this.Person = clsPeople.Find(PersonID);
            this.UserID = UserID;
            this.User=clsUser.FindByUserID(UserID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationDate = ApplicationDate;
            this.PaidFees = PaidFees;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);
            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(PersonID, ApplicationDate, ApplicationTypeID, 
                                                                    (byte) ApplicationStatus, LastStatusDate, PaidFees, UserID);

                return (this.ApplicationID != -1);

        }

        private bool _UpdateApplication()
        {
            if(clsApplicationData.UpdateApplication(ApplicationID,(byte)ApplicationStatus, LastStatusDate, PaidFees,UserID))
            {
                return true;
            }
            return false;
        }
        public static clsApplication FindBase(int ApplicationID)
        {
            int PersonID = -1, UserID = -1,TypeID=-1;
            decimal PaidFees = -1;
           byte Status = 0;
            DateTime AppDate=DateTime.Now,LastDate=DateTime.Now;

            if (clsApplicationData.FindApplicationByID(ApplicationID, ref PersonID, ref AppDate, ref TypeID, ref Status, ref LastDate, ref PaidFees, ref UserID))
            {
                return new clsApplication(ApplicationID, PersonID, UserID, (clsApplication.enStatus)Status, LastDate, AppDate, PaidFees, TypeID);
            }
            return null;
        }

        public bool CancelApplication()
        {
            this.ApplicationStatus = enStatus.enCancelled;
            this.LastStatusDate = DateTime.Now;
            if (clsApplicationData.UpdateStatus(ApplicationID, (byte)ApplicationStatus,DateTime.Now))
            {
                return this.Save();
            }
            else return false;
        }

        public bool CompeleteApplication()
        {
            this.ApplicationStatus = enStatus.enCompleted;
            this.LastStatusDate = DateTime.Now;
            return clsApplicationData.UpdateStatus(ApplicationID, (byte)ApplicationStatus, DateTime.Now);    
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            if (clsApplicationData.DeletApplication(ApplicationID))
            {
                return true;
            }
            else return false;
        }


        public bool Save()
        {
            switch(Mode)
            {
                case enMode.New:
                     if(_AddNewApplication())
                     { 
                        Mode = enMode.Update; 
                        return true;
                     }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplication();

            }
            return false;
        }


        public static int GetActiveApplicationIDForLicenseClass(int personid,int LicenseClassID,int TypeApplicationID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(personid,LicenseClassID,TypeApplicationID);
        }

       

        public static int GetActiveApplicationID(int personid,int ApplicationType)
        {
           return clsApplicationData.GetActiveApplicationID(personid, ApplicationType);
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationType)
        {
            return GetActiveApplicationID(PersonID, ApplicationType) != -1;
        }

    }
}
