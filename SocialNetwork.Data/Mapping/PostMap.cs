using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Mapping
{
    class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(m => m.description).IsRequired();
            Property(m => m.date).IsRequired();
            ToTable("Post");

           
            
            HasRequired(m => m.User).WithMany(m => m.Posts).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.Photo).WithMany(m => m.Posts).HasForeignKey(m => m.id_photo).WillCascadeOnDelete(false);

        }
    }
}
