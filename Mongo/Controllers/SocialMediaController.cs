using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.SocialMediaDto;
using Mongo.Service.SocialMediaServices;

namespace Mongo.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _socialMediaService.GetAllSocialMediaAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto _createSocialMediaDto)
        {
            await _socialMediaService.CreateSocialMediaAsync(_createSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }

        public async Task<IActionResult> DeleteSocialMedia(string id)
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            return RedirectToAction("SocialMediaList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto _updateSocialMediaDto)
        {
            await _socialMediaService.UpdateSocialMediaAsync(_updateSocialMediaDto);
            return RedirectToAction("SocialMediaList");
        }

    }
}
