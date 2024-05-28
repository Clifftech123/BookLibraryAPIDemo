using BookLibraryAPIDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibraryAPIDemo.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Title).IsRequired();
            entity.Property(b => b.Description).IsRequired(false);
            entity.Property(b => b.AuthorId).IsRequired();
            entity.Property(b => b.Price).IsRequired();
            entity.Property(b => b.CreatedDate).IsRequired();
            entity.Property(b => b.UpdatedDate).IsRequired();
            entity.Property(b => b.PublisherId).IsRequired();
            entity.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(c => c.CategoryId);
            entity.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
            entity.HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);
        }
    }
}
