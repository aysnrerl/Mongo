namespace Mongo.Dtos.CategoryDto
{
    public class GetCategoryByIdDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
