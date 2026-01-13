using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=3}

        public enTestType ID { get; set; }
        public  string Description {  get; set; }
        public string Title { get; set; }
        public decimal Fees {  get; set; }
       


        clsTestTypes(enTestType ID,string Title, string Description,decimal Fees)
        {
        this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.Fees = Fees; 
        }
        public static DataTable GetAllTestTypes()
        { return clsTestTypesData.GetAllTestTypes(); }

        public bool Update()
        {
            return clsTestTypesData.UpdateTestTypes((int)this.ID, this.Title, this.Fees, this.Description);

        }
       
        public static clsTestTypes Find(enTestType ID)
        {
            string Title = "", Description = "";
            decimal Fees = -1;
            if(clsTestTypesData.Find((int)ID,ref Title,ref Fees,ref Description))
            {
                return new clsTestTypes(ID,Title,Description,Fees);
            }
            return null;
        }

   
    
    
    }
}
