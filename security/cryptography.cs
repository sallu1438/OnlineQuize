using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineQuize.security
{
    public class cryptography
    {
        public static string encrypt(string encryptString)
        {
            byte[] bt = System.Text.ASCIIEncoding.ASCII.GetBytes(encryptString);
            string encryptedString = Convert.ToBase64String(bt);
            return encryptedString;
        }
    }
}