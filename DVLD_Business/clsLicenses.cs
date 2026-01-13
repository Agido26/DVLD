using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{
    public class clsLicenses
    {
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacemenForDameged = 3, ReplacementForLost = 4 }
        public int LicenseID { get; set; }
       public int ApplicationID {  get; set; }
        public clsApplication Application { get; set; }
       public int DriverID {  get; set; }
       public int LicenseClassID {  get; set; }
        public clsLinceseClasses LinceseClasse{ get; set; }
       public DateTime IssueDate {  get; set; }
       public DateTime ExpirationDate {  get; set; }
       public string Notes {  get; set; }
       public decimal PaidFees {  get; set; }
       public bool IsActive {  get; set; } 
       public enIssueReason IssueReason {  get; set; }
        public int CreatedByUserID {  get; set; }



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
        }
        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason,
            int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason= IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }





        public static bool IsLicenseExistByApplicationID(int ApplicationID,int LicClsID)
        {
            return clsLicensesData.IsLicenseExistByApplicationID(ApplicationID, LicClsID);

        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicClsID)
        {
            return clsLicensesData.IsLicenseExistByPersonID(PersonID, LicClsID);

        }

        public static int GetActiveLicense(int ApplicationID,int LicclsID)
        { return clsLicensesData.GetActiveLicenseID(ApplicationID, LicclsID); }

        public static bool HaveActiveLicense(int ApplicationID, int LicclsID)
        {
            return GetActiveLicense(ApplicationID,LicclsID) != -1;
        }

      public static int GetIssuReasonByApplicationID(int ApplicationID)
        {
            return clsLicensesData.GetIssueReasonbyApplicationID(ApplicationID);
        }
    
    }
}
