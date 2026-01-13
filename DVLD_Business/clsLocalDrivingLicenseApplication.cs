using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication: clsApplication
    {

      public  enum enMode { enAdd=1,enUpdate=2}
     public   enMode Mode;
        public int LocalDrivingLicenseID {  get; set; }
        public int LicenseClassID {  get; set; }
        public clsLinceseClasses Licenseclass {  get; set; }

       
    

        public string FullName { get { return base.Person.FullName; } }
       public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseID = -1;

            LicenseClassID = -1;
            Licenseclass = new clsLinceseClasses();

            Mode = enMode.enAdd;
        }

        clsLocalDrivingLicenseApplication(int LocalDriveLicenseID,int LicCalssID, int ApplicationID, int PersonID, int UserID, clsApplication.enStatus ApplicationStatus, DateTime LastStatusDate
                        , DateTime ApplicationDate, decimal PaidFees, int ApplicationTypeID)
        {
            this.LocalDrivingLicenseID = LocalDriveLicenseID;
            this.LicenseClassID = LicCalssID;
            this.Licenseclass = clsLinceseClasses.FindByID(LicCalssID);
            this.ApplicationID = ApplicationID;
            this.PersonID = PersonID;
            this.Person = clsPeople.Find(PersonID);
            this.UserID = UserID;
            this.User = clsUser.FindByUserID(UserID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationDate = ApplicationDate;
            this.PaidFees = PaidFees;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);

            Mode = enMode.enUpdate;
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingLicenseData.GetAllLocalDrivingLicense();
        }

        public static clsLocalDrivingLicenseApplication FindByLocalLicenseID(int Id)
        {
            int ApplicationID = -1, LicenseID = -1;
            bool isfind = clsLocalDrivingLicenseData.FindByLocalLicenseID(Id, ref ApplicationID, ref LicenseID);


            if (isfind)
            {
                clsApplication App = clsApplication.FindApplicationByID(ApplicationID);
                return new clsLocalDrivingLicenseApplication(Id,LicenseID,ApplicationID,App.PersonID,App.UserID,App.ApplicationStatus,App.LastStatusDate,App.ApplicationDate,App.PaidFees,App.ApplicationTypeID);
            }
            return null;
        }

        public static bool DeleteLocalApplicationByID(int LocalApplicationID)
        {
            return clsLocalDrivingLicenseData.DeleteByLocalDrivingLicenseApplicationID(LocalApplicationID);
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalApplicationID = -1, LicenseID = -1;
            bool isfind = clsLocalDrivingLicenseData.FindByApplicationID(ApplicationID, ref LocalApplicationID, ref LicenseID);
            if (isfind)
            {
                clsApplication App = clsApplication.FindApplicationByID(LocalApplicationID);
                return new clsLocalDrivingLicenseApplication(LocalApplicationID, LicenseID, ApplicationID, App.PersonID, App.UserID, App.ApplicationStatus, App.LastStatusDate, App.ApplicationDate, App.PaidFees, App.ApplicationTypeID);
            }
            return null;
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseID = clsLocalDrivingLicenseData.AddNewLocalDrivingLicenseApplication(this.LicenseClassID, this.ApplicationID);
            return LocalDrivingLicenseID != -1;
        }

        private bool _UpdateLocalDrivigLicenseApplication()
        {
            if (clsLocalDrivingLicenseData.UpdateLocalDrivingLicenseApplications(LocalDrivingLicenseID, ApplicationID, LicenseClassID))
            { return true; }
            return false;

        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.enAdd:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;

                case enMode.enUpdate:
                    return _UpdateLocalDrivigLicenseApplication();
            }
            return false;
        }

        public static bool IsThereActiveLicenseClass(int PersonID,int LicenseClassID,int TypeApplicatioonID)
        {   
                return clsApplication.GetActiveApplicationIDForLicenseClass(PersonID, LicenseClassID, TypeApplicatioonID) != -1;                    
        }
       
        public static int PassedTests(int LocalLicesnseID)
        {
            return clsLocalDrivingLicenseData.PassedTestCount(LocalLicesnseID);  
        }
       
        public int GetActiveLicenseID()
        {
            int LicID = clsLicensesData.GetActiveLicenseID(ApplicationID, LicenseClassID);
            return LicID;
        }

    }
}
