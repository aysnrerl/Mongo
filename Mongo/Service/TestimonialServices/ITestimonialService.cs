using Mongo.Dtos.TestimonialDto;

namespace Mongo.Service.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsync(string deleteTestimonialId);
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string getTestimonialById);
    }
}
