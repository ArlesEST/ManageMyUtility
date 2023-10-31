using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ManageMyUtility
{
    public class Credentials
    {
        public string Website { get; set; }
        public string Password { get; set; }
        public string User { get; set; }


        public override string ToString()
        {
            return $"{Website} {Password} {User}";
        }

    }
}
