using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        enum enMode { enAdd=0 ,enUpdate=1}
        enMode Mode=enMode.enAdd;

        public string Username {  get; set; }
        public string Password {  get; set; }
        public bool IsActive { get; set; }
        public int UserID { get; set; }
        public int PersonID { get; set; }

        private clsUser(string username,string password, bool isActive,int UserID,int PersonID)
        {
            Username = username;
            Password = password;
            IsActive = isActive;
            this.UserID = UserID;
            this.PersonID = PersonID;
            Mode=enMode.enUpdate;
        }
        public clsUser ()
        {
            UserID = -1;
            Username = "";
            PersonID = -1;
            Password = "";
            IsActive = false;
            Mode= enMode.enAdd;
        }
        public static clsUser Find(string username, string password)
        {
            bool Isactive = false;
            int UserID=-1, PersonID=-1;

           if( clsUserData.FindUser(username, password,ref Isactive,ref UserID,ref PersonID))
            {
                return new clsUser(username, password, Isactive,UserID,PersonID);
            }
            return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            bool Isactive = false;
            int UserID = -1;
            string UserName = "", Password="";

            if (clsUserData.FindUserByPersonID(PersonID,ref UserName, ref Password, ref Isactive, ref UserID))
            {
                return new clsUser(UserName, Password, Isactive, UserID, PersonID);
            }
            return null;
        }

        public static clsUser FindByUserID(int UserID)
        {
            bool Isactive = false;
            int PersonID = -1;
            string UserName = "", Password = "";

            if (clsUserData.FindUserByUserID(UserID,ref PersonID, ref UserName, ref Password, ref Isactive))
            {
                return new clsUser(UserName, Password, Isactive, UserID, PersonID);
            }
            return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        private  bool _AddNewUser()
        {
           UserID = clsUserData.AddNewUser(PersonID, Username, Password, IsActive);
            
            return UserID!=-1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUserInfo(this.UserID, this.Username, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.enAdd:
                    if (_AddNewUser())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false; 
                case enMode.enUpdate:
                    return _UpdateUser();

            }
            return false;
        }

        public bool DeleteUser()
        { return clsUserData.DeleteUser(this.UserID); }

    }
}
