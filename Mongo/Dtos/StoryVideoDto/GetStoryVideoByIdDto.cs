namespace Mongo.Dtos.StoryVideoDto
{
    public class GetStoryVideoByIdDto
    {
        public string StoryVideoId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
