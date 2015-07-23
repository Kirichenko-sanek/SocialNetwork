using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    public class User : BaseEntity
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long id_photo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool is_activated { get; set; }
        public string password_salt { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual List<Comments> Commentses { get; set; }
        public virtual List<Post> Posts { get; set; }
        
        public virtual List<Friends> Users { get; set; }
        public virtual List<Friends> Friendses { get; set; }
        public virtual List<UserInRoles> Useres { get; set; }

        public User()
        {
            Commentses = new List<Comments>();
            Posts = new List<Post>();
            Users = new List<Friends>();
            Friendses = new List<Friends>();
            Useres = new List<UserInRoles>();
        }
    }
}
