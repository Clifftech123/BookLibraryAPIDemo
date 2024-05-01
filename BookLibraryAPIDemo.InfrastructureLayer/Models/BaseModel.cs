using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPIDemo.InfrastructureLayer.Models
{
    internal class BaseModel 
    {
        [Key]
        public Guid Id { get; set; }

    }
}
