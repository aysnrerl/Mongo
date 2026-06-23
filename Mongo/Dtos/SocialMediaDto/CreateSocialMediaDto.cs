namespace Mongo.Dtos.SocialMediaDto
{
    public class CreateSocialMediaDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
