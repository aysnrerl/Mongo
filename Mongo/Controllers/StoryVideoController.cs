using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.StoryVideoDto;
using Mongo.Service.StoryVideoServices;

namespace Mongo.Controllers
{
    public class StoryVideoController : Controller
    {
        private readonly IStoryVideoService _storyVideoService;

        public StoryVideoController(IStoryVideoService storyVideoService)
        {
            _storyVideoService = storyVideoService;
        }

        public async Task<IActionResult> StoryVideoList()
        {
            var values = await _storyVideoService.GetAllStoryVideoAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateStoryVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStoryVideo(CreateStoryVideoDto _createStoryVideoDto)
        {
            await _storyVideoService.CreateStoryVideoAsync(_createStoryVideoDto);
            return RedirectToAction("StoryVideoList");
        }


        public async Task<IActionResult> DeleteStoryVideo(string id)
        {
            await _storyVideoService.DeleteStoryVideoAsync(id);
            return RedirectToAction("StoryVideoList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateStoryVideo(string id)
        {
            var value = await _storyVideoService.GetStoryVideoByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStoryVideo(UpdateStoryVideoDto _updateStoryVideoDto)
        {
            await _storyVideoService.UpdateStoryVideoAsync(_updateStoryVideoDto);
            return RedirectToAction("StoryVideoList");
        }
    }
}
