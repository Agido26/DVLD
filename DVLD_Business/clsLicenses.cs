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
        public clsDrivers Drivers { get; set; }
       public int LicenseClassID {  get; set; }
        public clsLinceseClasses LinceseClasse{ get; set; }
       public DateTime IssueDate {  get; set; }
       public DateTime ExpirationDate {  get; set; }
       public string Notes {  get; set; }
       public decimal PaidFees {  get; set; }
       public bool IsActive {  get; set; } 
       public enIssueReason IssueReason {  get; set; }
       public int CreatedByUserID {  get; set; }
       public clsUser CretedUserInfo { get; set; }


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
            this.Application = clsApplication.FindApplicationByID(ApplicationID);
            this.DriverID = DriverID;
            this.Drivers=clsDrivers.Find(DriverID);
            this.LicenseClassID = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason= IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.CretedUserInfo = clsUser.FindByUserID(CreatedByUserID);
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
            return clsLicenses.GetAllLicenses();

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
        { return clsLicensesData.GetActiveLicenseID(ApplicationID, LicclsID); }

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
    
    }
}
