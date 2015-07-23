using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    public class Roles : BaseEntity
    {
        public string name { get; set; }


        public virtual List<UserInRoles> Useres { get; set; }

        public Roles()
        {
            Useres = new List<UserInRoles>();
        }
    }
}
