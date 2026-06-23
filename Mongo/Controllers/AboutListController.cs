using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.AboutListDto;
using Mongo.Service.AboutListServices;

namespace Mongo.Controllers
{
    public class AboutListController : Controller
    {
        private readonly IAboutListService _aboutListService;

        public AboutListController(IAboutListService aboutListService)
        {
            _aboutListService = aboutListService;
        }

        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutListService.GetAllAboutListAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateAboutList()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutList(CreateAboutListDto _createAboutListDto)
        {
            await _aboutListService.CreateAboutListAsync(_createAboutListDto);
            return RedirectToAction("AboutList");
        }


        public async Task<IActionResult> DeleteAboutList(string id)
        {
            await _aboutListService.DeleteAboutListAsync(id);
            return RedirectToAction("AboutList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAboutList()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAboutList(UpdateAboutListDto _updateAboutListDto)
        {
            await _aboutListService.UpdateAboutListAsync(_updateAboutListDto);
            return RedirectToAction("AboutList");
        }
    }
}
