using AutoMapper;
using Mongo.Dtos.AboutListDto;
using Mongo.Dtos.AboutSection1Dto;
using Mongo.Dtos.AboutSection2Dto;
using Mongo.Dtos.FeatureDto;
using Mongo.Dtos.OrderDto;
using Mongo.Dtos.ProductDto;
using Mongo.Dtos.SocialMediaDto;
using Mongo.Dtos.SSSDto;
using Mongo.Dtos.StoryVideoDto;
using Mongo.Dtos.SubscribeDto;
using Mongo.Dtos.TestimonialDto;
using Mongo.Dtos.CategoryDto;
using Mongo.Entities;

namespace Mongo.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AboutList, ResultAboutListDto>().ReverseMap();
            CreateMap<AboutList, CreateAboutListDto>().ReverseMap();
            CreateMap<AboutList, UpdateAboutListDto>().ReverseMap();
            CreateMap<AboutList, GetAboutListByIdDto>().ReverseMap();

            CreateMap<AboutSection1, ResultAboutSection1Dto>().ReverseMap();
            CreateMap<AboutSection1, CreateAboutSection1Dto>().ReverseMap();
            CreateMap<AboutSection1, UpdateAboutSection1Dto>().ReverseMap();
            CreateMap<AboutSection1, GetAboutSection1ByIdDto>().ReverseMap();

            CreateMap<AboutSection2, ResultAboutSection2Dto>().ReverseMap();
            CreateMap<AboutSection2, CreateAboutSection2Dto>().ReverseMap();
            CreateMap<AboutSection2, UpdateAboutSection2Dto>().ReverseMap();
            CreateMap<AboutSection2, GetAboutSection2ByIdDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();


            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderByIdDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductByIdDto>().ReverseMap();

            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetSocialMediaByIdDto>().ReverseMap();

            CreateMap<SSS, ResultSSSDto>().ReverseMap();
            CreateMap<SSS, CreateSSSDto>().ReverseMap();
            CreateMap<SSS, UpdateSSSDto>().ReverseMap();
            CreateMap<SSS, GetSSSByIdDto>().ReverseMap();

            CreateMap<StoryVideo, ResultStoryVideoDto>().ReverseMap();
            CreateMap<StoryVideo, CreateStoryVideoDto>().ReverseMap();
            CreateMap<StoryVideo, UpdateStoryVideoDto>().ReverseMap();
            CreateMap<StoryVideo, GetStoryVideoByIdDto>().ReverseMap();

            CreateMap<Subscribe, ResultSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, UpdateSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, GetSubscribeByIdDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

        }
    }
}
