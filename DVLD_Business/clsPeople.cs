using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using System.Data;
using System.Security.Permissions;
namespace DVLD_Business
{
    public class clsPeople
    {
       private enum enMode {enAddNew=1, enUpdate=2 }
       private enMode Mode=enMode.enAddNew;
        public int PersonID { get; set;}
        public string First_Name {  get; set;}
        public string Second_Name {  get; set;}
        public string Third_Name {  get; set;}
        public string Last_Name {  get; set;}
        public string FullName { get { return First_Name + " " + Second_Name + " " + Third_Name + " " + Last_Name; } }
        public string NationalNo {  get; set;}
        public string Address {  get; set;}
        public string Email {  get; set;}
        public string Phone {  get; set;}
        public byte Gendor { get; set; }
        public DateTime DateOfBirth  { get; set; }
        public string Image_Path {  get; set;}
        public int CountryID {  get; set;}

       private clsPeople (int ID,string First_Name,string Second_Name,string Third_Name,string Last_Name,
                          string National_NO,string Address, string Email, string Phone,byte Gendor,
                           DateTime Date_Of_Birth, string Image_Path,int Country_ID) 
        {
            this.PersonID = ID;
            this.First_Name = First_Name;
            this.Second_Name = Second_Name;
            this.Third_Name = Third_Name;
            this.Last_Name = Last_Name;
            this.NationalNo = National_NO;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;
            this.DateOfBirth = Date_Of_Birth;
            this.Image_Path = Image_Path;
            this.CountryID = Country_ID;
            this.Gendor = Gendor;
            Mode = enMode.enUpdate;
        }


        public clsPeople()
        {this.PersonID = -1;
            this.First_Name = "";
            this.Second_Name = "";
            this.Third_Name = "";
            this.Last_Name = "";
            this.NationalNo = "";
            this.Address = "";
            this.Email = "";
            this.Phone = "";
            this.DateOfBirth = DateTime.Now;
            this.Image_Path = "";
            this.CountryID = -1;
            this.Gendor = 5;
            Mode = enMode.enAddNew;
        }


        public static  DataTable GetAllPeople()
        {

            return clsPeopleData.Get_All_People();

        }
       

        public static clsPeople Find(int ID)
        {
             string FirstName="" , SecondName="", ThirdName="" ,LastName="", NationalNo="",Phone="",Email=""
                ,Address="", ImagePath="";
            DateTime Birth=new DateTime();
            byte Gendor = 0;
            int CountryID = -1;

            if (clsPeopleData.Find_Person_By_ID(ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo
                                             , ref Birth, ref Gendor, ref Phone, ref Email, ref CountryID, ref Address, ref ImagePath))
            { return new clsPeople(ID,FirstName, SecondName, ThirdName, LastName, NationalNo, Address, Email, Phone, Gendor, Birth, ImagePath, CountryID); }
            else return null;
        }

        public static clsPeople Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",  Phone = "", Email = ""
               , Address = "", ImagePath = "";
            DateTime Birth = new DateTime();
            byte Gendor = 0;
            int CountryID = -1;
            int ID = -1;
            if (clsPeopleData.Find_Person_By_NationalNo(NationalNo,ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName
                                             , ref Birth, ref Gendor, ref Phone, ref Email, ref CountryID, ref Address, ref ImagePath))
            { return new clsPeople(ID, FirstName, SecondName, ThirdName, LastName, NationalNo, Address, Email, Phone, Gendor, Birth, ImagePath, CountryID); }
            else return null;
        }

        private bool _Add_New_Person()
        {
            this.PersonID= clsPeopleData.Add_New_People(this.First_Name, this.Second_Name, this.Third_Name, this.Last_Name, this.NationalNo, this.DateOfBirth,
                                                this.Gendor, this.Phone, this.Email, this.CountryID, this.Address, this.Image_Path);

            return (this.PersonID != -1);
        }

        private bool _Update_Person_Infos()
        {
            return clsPeopleData.Update_Person_Infos(this.PersonID,this.First_Name,this.Second_Name,
                                                     this.Third_Name,this.Last_Name,this.NationalNo,this.DateOfBirth,
                                                     this.Gendor,this.Phone,this.Email,this.CountryID,this.Address,this.Image_Path);
        }
       public static bool Delete_Person_By_ID(int ID)
        {
            return clsPeopleData.Delete_Person_BY_ID(ID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.enAddNew:
                    if (_Add_New_Person())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _Update_Person_Infos();

            }
            return false;

        }

        public static bool IsPersonExsist(int ID) 
        {
            return (clsPeople.Find(ID) != null);

        }
        public static bool IsPersonExsist(string NationalNo)
        {
            return (clsPeople.Find(NationalNo) != null);

        }

    }
}
