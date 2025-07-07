namespace RecipeManagement.Business.Dtos
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string CuisineType { get; set; }
        public string PreparationTime { get; set; }
        public string Difficulty { get; set; }
        public int NumberOfServings { get; set; }
        public string Status { get; set; }
    }
}
