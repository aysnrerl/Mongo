namespace Mongo.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AboutListCollectionName { get; set; }
        public string AboutSection1CollectionName { get; set; }
        public string AboutSection2CollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string StoryVideoCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string SSSCollectionName { get; set; }
        public string SocialMediaCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string SubscribeCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
    }
}
