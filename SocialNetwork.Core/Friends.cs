using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core
{
    public class Friends : BaseEntity
    {
        public long id_user { get; set; }
        public long id_friend { get; set; }

        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; } 
        
        
    }
}
