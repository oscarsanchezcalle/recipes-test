using System.ComponentModel.DataAnnotations;

namespace RecipeManagement.Business.Dtos
{
    public class CreateRecipeDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        [StringLength(50)]
        public string CuisineType { get; set; }

        [Required]
        [StringLength(50)]
        public string PreparationTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Difficulty { get; set; }

        public int NumberOfServings { get; set; }

        public string Status { get; set; }
    }
}
