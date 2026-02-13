using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
      public  enum enMode { enAdd=0,enUpdate=1,enRetake=3}
      public  enMode Mode = enMode.enAdd;
        public int TestAppointmentID {  get; set; }
        public clsTestTypes.enTestType TestTypeID {  get; set; }
       public clsTestTypes TestTypes { get; set; }
        public int LocalDrivingLicenseID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicense {  get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees {  get; set; }
        public int CreatByUserID {  get; set; }
        public bool IsLocked {  get; set; }
        public int ReTakeTestApplicationID {  get; set; }
        public clsApplication RetakeAppInfo { get; set; }

        public clsTestAppointment ()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = clsTestTypes.enTestType.VisionTest;
            this.LocalDrivingLicenseID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatByUserID = -1;
            this.ReTakeTestApplicationID = -1;
            this.IsLocked = false;
            Mode=enMode.enAdd;
        }
        private clsTestAppointment(int TestAppID, clsTestTypes.enTestType TestTypeID,int LocalDrivingLicenseID,DateTime AppointmentDate,
            decimal PaidFees,int CreatByUserID,bool IsLocked,int ReTakeAppID)
        {
            this.TestAppointmentID = TestAppID;
            this.TestTypeID = TestTypeID;
            this.TestTypes = clsTestTypes.Find((clsTestTypes.enTestType)TestTypeID);
            this.LocalDrivingLicenseID = LocalDrivingLicenseID;
            this.LocalDrivingLicense=clsLocalDrivingLicenseApplication.FindByLocalLicenseID(this.LocalDrivingLicenseID);
            this.AppointmentDate = AppointmentDate;
            this.PaidFees= PaidFees;
            this.CreatByUserID = CreatByUserID;
            this.ReTakeTestApplicationID = ReTakeAppID;
            this.RetakeAppInfo = clsApplication.FindBase(ReTakeAppID);
            this.IsLocked= IsLocked;
            Mode=enMode.enUpdate;
        }


        public static DataTable GetAllTestAppointments()
        { return clsTestAppointmentsData.GetAllTestAppointments(); }

        public static DataTable GetApplicationTestAppointmentPerTestType(int LocalLicenseID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationTestAppointmentPerTestType(LocalLicenseID, TestTypeID);
        }


        public static clsTestAppointment FindTestAppointmentByID(int TestAppointmentID)
        {
            int  LocalDrivingLicenseID = -1, CreatByUserID = -1, ReTakeAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;
            int TestTypeID = 0 ;
            if (clsTestAppointmentsData.FindTestAppointment(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseID,
              ref AppointmentDate, ref PaidFees, ref CreatByUserID, ref IsLocked, ref ReTakeAppID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestTypes.enTestType)TestTypeID, LocalDrivingLicenseID,
               AppointmentDate, PaidFees, CreatByUserID, IsLocked, ReTakeAppID);
            }
            return null;
        }

        public static clsTestAppointment GetLastTestAppointment(int LocalLicenseID, clsTestTypes.enTestType testType)
        {
            int TestAppointmentID=-1;
          int CreatByUserID = -1, ReTakeAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;
           
            if (clsTestAppointmentsData.GetLastTestAppointment(LocalLicenseID,(int) testType,ref TestAppointmentID,
              ref AppointmentDate, ref PaidFees, ref CreatByUserID, ref IsLocked, ref ReTakeAppID))
            {
                return new clsTestAppointment(TestAppointmentID, testType, LocalLicenseID,
               AppointmentDate, PaidFees, CreatByUserID, IsLocked, ReTakeAppID);
            }
            return null;
        }


        private bool _AddNewTestAppointment()
        {
            int TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointments( (int)TestTypeID,  LocalDrivingLicenseID,  AppointmentDate,
             PaidFees,  CreatByUserID,  IsLocked,  this.ReTakeTestApplicationID);
            return TestAppointmentID != -1;
        }
    
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointments(TestAppointmentID,(int)TestTypeID, LocalDrivingLicenseID, AppointmentDate,
             PaidFees, CreatByUserID, IsLocked, this.ReTakeTestApplicationID);
        }
      
        public bool Save()
        {


            switch(Mode)
            {
                case enMode.enAdd:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;

                case enMode.enUpdate:
                    return _UpdateTestAppointment();

                case enMode.enRetake:
                    
                    return true;
            }
            return false;
        }
    
        public int _GetTestID()
        { return clsTestAppointmentsData.GetTestID(TestAppointmentID); }
        public static bool DeleteTestAppointmentByID(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteByTestAppointmentID(TestAppointmentID);
        }

        
       
    }
}
