using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_kepeer_1
{
    [Serializable]
    public class XML_user
    {
        public string Passport { get; set; }

       
        public string Resource { get; set; }
        public float Amount { get; set; }


        // стандартный конструктор без параметров
        public XML_user()
        { }

        public XML_user(string passport,  string resource, float amount)
        {
            Passport = passport;           
            Resource = resource;
            Amount = amount;
        }
    }
   
    
}
