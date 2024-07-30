using System.ComponentModel.DataAnnotations;

namespace Movies.Domain.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
