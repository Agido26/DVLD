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
      public  enum enMode { enAdd=0,enUpdate=1}
      public  enMode Mode = enMode.enAdd;
        public int TestAppointmentID {  get; set; }
        public int TestTypeID {  get; set; }
       public clsTestTypes TestTypes { get; set; }
        public int LocalDrivingLicenseID { get; set; }
        public clsLocalDrivingLicenseApplication LocalDrivingLicense {  get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees {  get; set; }
        public int CreatByUserID {  get; set; }
        public bool IsLocked {  get; set; }
        public int ReTakeTestApplicationID {  get; set; }


        public clsTestAppointment ()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatByUserID = -1;
            this.ReTakeTestApplicationID = -1;
            this.IsLocked = false;
            Mode=enMode.enAdd;
        }
        private clsTestAppointment(int TestAppID,int TestTypeID,int LocalDrivingLicenseID,DateTime AppointmentDate,
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
            this.IsLocked= IsLocked;
            Mode=enMode.enUpdate;
        }


        public static DataTable GetAllTestAppointments()
        { return clsTestAppointmentsData.GetAllTestAppointments(); }


        public static clsTestAppointment FindTestAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = -1, LocalDrivingLicenseID = -1, CreatByUserID = -1, ReTakeAppID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            bool IsLocked = false;
            if (clsTestAppointmentsData.FindTestAppointment(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseID,
              ref AppointmentDate, ref PaidFees, ref CreatByUserID, ref IsLocked, ref ReTakeAppID))
            {
                return new clsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseID,
               AppointmentDate, PaidFees, CreatByUserID, IsLocked, ReTakeAppID);
            }
            return null;
        }




        private bool _AddNewTestAppointment()
        {
            int TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointments( TestTypeID,  LocalDrivingLicenseID,  AppointmentDate,
             PaidFees,  CreatByUserID,  IsLocked,  this.ReTakeTestApplicationID);
            return TestAppointmentID != -1;
        }
    
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointments(TestAppointmentID,TestTypeID, LocalDrivingLicenseID, AppointmentDate,
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
            }
            return false;
        }
    
        public static bool DeleteTestAppointmentByID(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteByTestAppointmentID(TestAppointmentID);
        }

        public static bool IsThereActiveTestAppointmentIDByLocalLicenseID(int LocalLicenseID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.IsThereActiveAppointmentByLocalLicenseID(LocalLicenseID, (int)TestTypeID);
        }
        public static bool IsThereTestAppointmentIDByLocalLicenseID(int LocalLicenseID, clsTestTypes.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.IsThereAppointmentByLocalLicenseID(LocalLicenseID, (int)TestTypeID);
        }
        public static int CountTrailsByLocalID(int LocalID, int TestTypeID) 
        {
        return clsTestAppointmentsData.CountTrails(LocalID, TestTypeID);
        }
        public int CountTrails()
        {
            return clsTestAppointmentsData.CountTrails(this.LocalDrivingLicenseID, this.TestTypeID);
        }
        public static DataTable GetAllTestAppointmentsByLocalID(int LocalLicenseID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetAllTestAppointmentsByLocalID(LocalLicenseID, TestTypeID);
        }
    }
}
