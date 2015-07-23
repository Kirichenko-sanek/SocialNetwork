using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    public class Comments : BaseEntity
    {
        public long id_user { get; set; }
        public long id_post { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
