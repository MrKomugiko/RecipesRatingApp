using System.ComponentModel.DataAnnotations;

namespace MyServices
{
    public class RecipeAddRequestDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required] [MaxLength(50)]
        public string Title { get; set; }
        [Required] [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string UrlImage { get; set; }
    }
}