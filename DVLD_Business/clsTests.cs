using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTests
    {
        enum enMode { enAdd=0,enUpdate=1}
        enMode Mode;
        public int TestID {  get; set; }
        public int TestAppointmentID {  get; set; }
       public bool TestResult {  get; set; }
        public string Notes {  get; set; }
        public int CreatedByUserID {  get; set; }
        clsUser User;


        public clsTests()
        {

            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
            Mode= enMode.enAdd;
        }
        private clsTests(int testID, int TestAppointmentID, bool TestResult, string Notes, int UserID)
        {
            this.TestID = testID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = UserID;
            Mode = enMode.enUpdate;
        }

       public static clsTests FindTestByID(int testID)
        {
            int TestAppointment=-1, UserID = -1;
            string Note = "";
            bool result = false;
            if( clsTestsData.FindTests(testID,ref TestAppointment,ref result,ref Note,ref UserID))
            {
                return new clsTests(testID, TestAppointment, result, Note, UserID);
            }
            return null;
        }

        public static clsTests FindTestByTestAppointmentID(int testAppointmentID)
        {
            int testID = -1, UserID = -1;
            string Note = "";
            bool result = false;
            if (clsTestsData.FindTestByAppointmentID(testAppointmentID, ref testID, ref result, ref Note, ref UserID))
            {
                return new clsTests(testID, testAppointmentID,  result, Note, UserID);
            }
            return null;
        }


        private bool _AddNewTest()
        {

            int NewTestID = clsTestsData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return NewTestID != -1;
        }
        private bool _UpdateTest()
        {
            if (clsTestsData.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID))
            {
                return true;
            }
            return false;

        }


        public static bool DeleteTestByID(int TestID)
        {
            return clsTestsData.DeleteByTestID(TestID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.enAdd:
                    if(_AddNewTest())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    return false;

                case enMode.enUpdate:
                    return _UpdateTest();
            }
            return false;


        }

        public static bool TestResultByTestID(int TestID,clsTestTypes.enTestType TestType)
        {
            return clsTestsData.TestResultByTestID(TestID,(int)TestType);
        }
        public static bool TestResultByTestApplointmentID(int TestAppointmentID, clsTestTypes.enTestType TestType)
        {
            return clsTestsData.TestResultByTestAppointmentsID(TestAppointmentID,(int)TestType);
        }
        public static bool TestResultByLocalDrivingLicenseID(int LocalDrivingLiceseID, clsTestTypes.enTestType TestType)
        {
            return clsTestsData.TestResultByLocalDrivingLicenseID(LocalDrivingLiceseID, (int)TestType);
        }

    }
}
