using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLinceseClasses
    {
        public int ID;
        public string className;
        public string classDiscription;
        public byte Age;
        public byte validLength;
        public decimal ClassFees;

        clsLinceseClasses(int ID,string classname,
                          string discription,byte age,byte validlength,decimal classfees)
        {
            this.ID = ID;
            this.className = classname;
            this.classDiscription = discription;
            this.Age = age;
            this.validLength= validlength;
            this.ClassFees = classfees;

        }

        public clsLinceseClasses()
        {
            this.ID = -1;
            this.className = "";
            this.classDiscription = "";
            this.Age = 0;
            this.validLength =0;
            this.ClassFees = -1;

        }

        public static DataTable GetAllLincesClasses()
        {
            return clsLincesClassesData.GetAllLinceseClasses();
        }


        public static clsLinceseClasses FindByID(int ID)
        {
            string ClassName = "", ClassDes = "";
            byte MinAge = 0, ValidLength = 0;
            decimal ClassFees = -1;

            if(clsLincesClassesData.FindLicenseClassByID(ID,ref ClassName,ref ClassDes,ref MinAge,ref ValidLength,ref ClassFees))
            {
                return new clsLinceseClasses(ID,ClassName,ClassDes,MinAge,ValidLength,ClassFees);

            }
            return null;
        }


    }
}
