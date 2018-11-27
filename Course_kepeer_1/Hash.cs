using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Course_kepeer_1
{
    class Hash
    {
        public static string connect_str = @"Data Source=DESKTOP-57CME0L;Initial Catalog=Bank_DB;User Id = bank_manager; Password = system";
        public static string connect_str_manager = @"Data Source=DESKTOP-57CME0L;Initial Catalog=Bank_DB;User Id = Main_manager; Password = system";

        public static string GetHash(string  password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password.ToString());
            MD5CryptoServiceProvider cSP = new MD5CryptoServiceProvider();
            byte[] byteHash = cSP.ComputeHash(bytes);
            string hash = String.Empty;
            foreach(byte b in byteHash)
            {
                hash += String.Format("{0:x2}", b);
            }
            return hash;
        }
    }
}
