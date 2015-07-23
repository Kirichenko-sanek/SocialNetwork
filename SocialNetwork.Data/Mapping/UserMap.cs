using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Mapping
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.first_name).IsRequired().HasMaxLength(20);
            Property(m => m.last_name).IsRequired().HasMaxLength(20);
            Property(m => m.email).IsRequired();
            Property(m => m.password).IsRequired();
            Property(m => m.is_activated).IsRequired();
            Property(m => m.password_salt).IsRequired();
            ToTable("User");

            HasRequired(m => m.Photo).WithMany(m => m.Useres).HasForeignKey(m => m.id_photo).WillCascadeOnDelete(false);
        }       
    }
}
