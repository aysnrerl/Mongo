namespace Mongo.Dtos.SSSDto
{
    public class CreateSSSDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
