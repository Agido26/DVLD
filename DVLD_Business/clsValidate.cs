using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsValidate
    {
        public static bool ValidateEmail(string Email)
        {
            if (Email.Contains("@gmail.com") || Email == "")
            {
                return true;
            }
            return false;
        }


      
    }
}
