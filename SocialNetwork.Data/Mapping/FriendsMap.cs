using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Mapping
{
    class FriendsMap : EntityTypeConfiguration<Friends>
    {       
        public FriendsMap()
        {
            
            ToTable("Friends");

            HasRequired(m => m.User1).WithMany(m => m.Users).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.User2).WithMany(m => m.Friendses).HasForeignKey(m => m.id_friend).WillCascadeOnDelete(false);
        }
    }
}
