namespace Mongo.Dtos.SocialMediaDto
{
    public class ResultSocialMediaDto
    {
        public string SocialMediaId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
