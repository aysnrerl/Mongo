using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.AboutSection2Dto;
using Mongo.Service.AboutSection2Services;

namespace Mongo.Controllers
{
    public class AboutSection2Controller : Controller
    {
        private readonly IAboutSection2Service _aboutSection2Service;

        public AboutSection2Controller(IAboutSection2Service aboutSection2Service)
        {
            _aboutSection2Service = aboutSection2Service;
        }

        public async Task<IActionResult> AboutSection2List()
        {
            var values = await _aboutSection2Service.GetAllAboutSection2Async();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateAboutSection2()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAboutSection2(CreateAboutSection2Dto _createAboutSection2Dto)
        {
            await _aboutSection2Service.CreateAboutSection2Async(_createAboutSection2Dto);
            return RedirectToAction("AboutSection2List");
        }


        public async Task<IActionResult> DeleteAboutSection2(string id)
        {
            await _aboutSection2Service.DeleteAboutSection2Async(id);
            return RedirectToAction("AboutSection2List");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAboutSection2(string id)
        {
            var value = await _aboutSection2Service.GetAboutSection2ByIdAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAboutSection2(UpdateAboutSection2Dto _updateAboutSection2Dto)
        {
            await _aboutSection2Service.UpdateAboutSection2Async(_updateAboutSection2Dto);
            return RedirectToAction("AboutSection2List");
        }
    }
}
