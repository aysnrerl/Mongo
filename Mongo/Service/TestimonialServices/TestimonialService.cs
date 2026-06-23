using AutoMapper;
using Mongo.Dtos.TestimonialDto;
using Mongo.Entities;
using Mongo.Settings;
using MongoDB.Driver;

namespace Mongo.Service.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>
                (_databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialCollection.InsertOneAsync(value);
        }

        public async Task DeleteTestimonialAsync(string deleteTestimonialId)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == deleteTestimonialId);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var value = await _testimonialCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(value);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string getTestimonialById)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == getTestimonialById).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(value);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == updateTestimonialDto.TestimonialId, value);
        }
    }
}
