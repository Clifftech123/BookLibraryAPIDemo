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
                    Id = 1,
                    Name = "Tech",
                    Description = "This is about Tech"
                },
                new Category
                {
                    Id = 2,
                    Name = "Finance ",
                    Description = "Books on Finance "
                },
                new Category
                {
                    Id = 3,
                    Name = "Science",
                    Description = "Books on science and nature"
                }
               );
        }
    }
}