using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    public class Post : BaseEntity
    {
        public long id_user { get; set; }
        public long id_photo { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public virtual User User { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual List<Comments> Commentses { get; set; }

        public Post()
        {
            Commentses = new List<Comments>();
        }

    }
}
