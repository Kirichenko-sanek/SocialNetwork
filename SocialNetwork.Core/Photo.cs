using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    public class Photo : BaseEntity
    {
        public string name { get; set; }

        public virtual List<Post> Posts { get; set; }
        public virtual List<User> Useres { get; set; }

        public Photo()
        {
            Posts = new List<Post>();
            Useres = new List<User>();
        }
    }
}
