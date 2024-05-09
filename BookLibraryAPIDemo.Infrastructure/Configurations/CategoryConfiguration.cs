using BookLibraryAPIDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibraryAPIDemo.Infrastructure.Configurations
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired();
            entity.HasData(
                new Category
                {
                    Id = new Guid(),
                    Name = "Tech",
                    Description = "This is about Tech"
                },
                new Category
                {
                    Id = new Guid(),
                    Name = "Finance ",
                    Description = "Books on Finance "
                },
                new Category
                {
                    Id = new Guid(),
                    Name = "Science",
                    Description = "Books on science and nature"
                }
               );
        }
    }
}