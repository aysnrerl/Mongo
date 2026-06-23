using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.TestimonialDto;
using Mongo.Entities;
using Mongo.Service.TestimonialServices;

namespace Mongo.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllTestimonialAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto _createTestimonialDto)
        {
            await _testimonialService.CreateTestimonialAsync(_createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonialByIdAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto _updateTestimonialDto)
        {
            await _testimonialService.UpdateTestimonialAsync(_updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }
    }
}
