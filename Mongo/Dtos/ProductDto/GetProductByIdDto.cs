namespace Mongo.Dtos.ProductDto
{
    public class GetProductByIdDto
    {
        public string ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public int TotalTime { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
