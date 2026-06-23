namespace Mongo.Dtos.SSSDto
{
    public class ResultSSSDto
    {
        public string SSSId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
