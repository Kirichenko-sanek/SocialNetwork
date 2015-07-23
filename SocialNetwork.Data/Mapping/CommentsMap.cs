using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SocialNetwork.Core;

namespace SocialNetwork.Data.Mapping
{
    class CommentsMap : EntityTypeConfiguration<Comments>
    {
        public CommentsMap()
        {
            HasKey(m =>m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);            
            Property(m => m.description).IsRequired();
            Property(m => m.date).IsRequired();
            ToTable("Comments");

            HasRequired(m => m.User).WithMany(m => m.Commentses).HasForeignKey(m => m.id_user).WillCascadeOnDelete(false);
            HasRequired(m => m.Post).WithMany(m => m.Commentses).HasForeignKey(m => m.id_post).WillCascadeOnDelete(false);
            
            



                
        }
    }
}
