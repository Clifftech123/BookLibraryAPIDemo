using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPIDemo.InfrastructureLayer.Models
{
     public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

    }
}
