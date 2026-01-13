using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationType
    {

        public enum enApplicationType { NewLocalDrivingLicense=1, RenewLocalLicense=2,
            ReplacementForLost=3, ReplacementForDamged=4, 
            ReleaseDetained=5, InternationalLicense=6, RetakeTest=7 }

       public enApplicationType ID {  get; set; }
       public string Title {  get; set; }
       public decimal Fees {  get; set; }


        public clsApplicationType()
        {
            this.ID = enApplicationType.NewLocalDrivingLicense;
            this.Title = "";
            this.Fees = -1;

        }
        public clsApplicationType(int ID, string Title, decimal fees)
        {
            this.ID = (enApplicationType)ID;
            this.Title = Title;
            this.Fees = fees;

        }

        public static DataTable GetAllApplicationType()
        {
            return clsApplicationTypeData.GetAllApplicationType();
        }
        public  bool UpdateApplicationType(int ID)
        {
           
            if(clsApplicationTypeData.UpdateApplicationTypes(ID,this.Title, this.Fees))
            {
                return true;
            }
            return false;
        }

        public static clsApplicationType Find(int ID)
        {
            string title = "";
            decimal fees = -1;
            if(clsApplicationTypeData.Find(ID,ref title,ref fees))
            {
                return new clsApplicationType(ID, title, fees);
            }
            return null;
        }

    }
}
