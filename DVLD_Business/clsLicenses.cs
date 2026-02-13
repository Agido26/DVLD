using DVLD_Buisness;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsLicenses
    {
        enum enMode { Addnew=1,Update=2}
        enMode _Mode=enMode.Addnew;
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacemenForDameged = 3, ReplacementForLost = 4 }
        public int LicenseID { get; set; }
       public int ApplicationID {  get; set; }
        public clsApplication Application { get; set; }
       public int DriverID {  get; set; }
        public clsDriver Drivers { get; set; }
       public int LicenseClassID {  get; set; }
        public clsLinceseClasses LinceseClass{ get; set; }
       public DateTime IssueDate {  get; set; }
       public DateTime ExpirationDate {  get; set; }
       public string Notes {  get; set; }
       public decimal PaidFees {  get; set; }
       public bool IsActive {  get; set; } 
       public enIssueReason IssueReason {  get; set; }
       public int CreatedByUserID {  get; set; }
       public clsUser CretedUserInfo { get; set; }
        public clsDetainedLicense DetainInfo;
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public string FullName { get { return (Application.Person.FullName); } }

        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            _Mode = enMode.Addnew;
        }
        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason,
            int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.Application = clsApplication.FindBase(ApplicationID);
            this.DriverID = DriverID;
            this.Drivers=clsDriver.Find(DriverID);
            this.LicenseClassID = LicenseClass;
            this.LinceseClass = clsLinceseClasses.FindByID(LicenseClassID);
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason= IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.CretedUserInfo = clsUser.FindByUserID(CreatedByUserID);
            DetainInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
            _Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = clsLicensesData.AddNewLicenses(this.ApplicationID, this.DriverID, this.LicenseClassID,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return clsLicensesData.UpdateLicenses(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClassID,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }
        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (clsLicensesData.FindLicense(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

    
        public static bool IsLicenseExistByApplicationID(int ApplicationID,int LicClsID)
        {
            return clsLicensesData.IsLicenseExistByApplicationID(ApplicationID, LicClsID);

        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicClsID)
        {
            return clsLicensesData.IsLicenseExistByPersonID(PersonID, LicClsID);

        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();

        }
        public DataTable GetDriver()
        {
            return clsLicensesData.GetDriverLicenses(this.DriverID);

        }

        public DataTable GetIntrnationalDriver()
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(this.DriverID);

        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Addnew:
                    if (_AddNewLicense())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static int GetActiveLicense(int ApplicationID,int LicclsID)
        { return clsLicensesData.GetActiveLicenseIDByPersonID(ApplicationID, LicclsID); }

        public static bool HaveActiveLicense(int ApplicationID, int LicclsID)
        {
            return GetActiveLicense(ApplicationID,LicclsID) != -1;
        }

        public static enIssueReason GetIssuReasonByApplicationID(int ApplicationID)
        {
            return (enIssueReason)clsLicensesData.GetIssueReasonbyApplicationID(ApplicationID);
        }


        public static bool deactiveLicense(int licenseid)
        {
            return clsLicensesData.DeactivateLicense(licenseid);
        }

        public bool deactiveLicense()
        {
            return clsLicensesData.DeactivateLicense(this.LicenseID);
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacemenForDameged:
                    return "Replacement for Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }
    
        public bool IsDetained()
        {
            return clsDetainedLicense.IsLicenseDetained(LicenseID);
        }
        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

          
            Application.PersonID = this.Drivers.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewLocalLicense;
            Application.ApplicationStatus = clsApplication.enStatus.enCompleted;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewLocalLicense).Fees;
            Application.UserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LinceseClass.validLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LinceseClass.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            deactiveLicense();

            return NewLicense;
        }
        public clsLicenses Replace(enIssueReason IssueReason, int CreatedByUserID)
        {


            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.PersonID = this.Drivers.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.ReplacemenForDameged) ?
                (int)clsApplication.enApplicationType.ReplacementForDamged :
                (int)clsApplication.enApplicationType.ReplacementForLost;

            Application.ApplicationStatus = clsApplication.enStatus.enCompleted;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).Fees;
            Application.UserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            deactiveLicense();

            return NewLicense;
        }
        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.PersonID = this.Drivers.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetained;
            Application.ApplicationStatus = clsApplication.enStatus.enCompleted;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetained).Fees;
            Application.UserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;


            return this.DetainInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }
        public int Detain(float FineFees,int CretaedbyUserID)
        {
            clsDetainedLicense Detain = new clsDetainedLicense();

            Detain.LicenseID = this.LicenseID;
            Detain.DetainDate = DateTime.Now;
            Detain.FineFees =Convert.ToSingle(FineFees);
            Detain.CreatedByUserID = CretaedbyUserID;

            if(!Detain.Save())
            {
                return -1;
            }
            return Detain.DetainID;


        }
    
    }
}
