using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Mapping
{
    class UserInRolesMap : EntityTypeConfiguration<UserInRoles>
    {
        public UserInRolesMap()
        {
            //HasKey(s => new { s.id_user, s.id_roles });         
            //Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(m => m.id_user).IsRequired();
            //Property(m => m.id_roles).IsOptional();
            ToTable("UserInRoles");

            HasRequired(m => m.User).WithMany(m => m.Useres).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.Roles).WithMany(m => m.Useres).HasForeignKey(m => m.id_roles).WillCascadeOnDelete(false);
        }
    }
}
