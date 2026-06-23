using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.AboutSection1Dto;
using Mongo.Service.AboutSection1Services;

namespace Mongo.Controllers
{
    public class AboutSection1Controller : Controller
    {
        private readonly IAboutSection1Service _aboutSection1Service;

        public AboutSection1Controller(IAboutSection1Service aboutSection1Service)
        {
            _aboutSection1Service = aboutSection1Service;
        }

        // Sol menüde verdiğin linke göre burası "AboutSection1List" kalabilir 
        // (Eğer sol menüde /AboutSection1/Index yazdıysan burayı Index yapabilirsin)
        public async Task<IActionResult> AboutSection1List()
        {
            var values = await _aboutSection1Service.GetAllAboutSection1Async();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAboutSection1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutSection1(CreateAboutSection1Dto _createAboutSection1Dto)
        {
            await _aboutSection1Service.CreateAboutSection1Async(_createAboutSection1Dto);
            return RedirectToAction("AboutSection1List");
        }

        public async Task<IActionResult> DeleteAboutSection1(string id)
        {
            await _aboutSection1Service.DeleteAboutSection1Async(id);
            return RedirectToAction("AboutSection1List");
        }

        // DÜZELTTİĞİMİZ KISIM: Güncellenecek veriyi id ile bulup formun içine dolduruyoruz
        [HttpGet]
        public async Task<IActionResult> UpdateAboutSection1(string id)
        {
            var value = await _aboutSection1Service.GetAboutSection1ByIdAsync(id);
            return View(value); // Bulunan eski veriyi form sayfasına paslıyoruz
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAboutSection1(UpdateAboutSection1Dto _updateAboutSection1Dto)
        {
            await _aboutSection1Service.UpdateAboutSection1Async(_updateAboutSection1Dto);
            return RedirectToAction("AboutSection1List");
        }
    }
}