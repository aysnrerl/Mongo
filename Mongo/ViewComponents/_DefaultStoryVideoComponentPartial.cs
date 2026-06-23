using Microsoft.AspNetCore.Mvc;
using Mongo.Service.StoryVideoServices;

namespace Mongo.ViewComponents
{
    public class _DefaultStoryVideoComponentPartial : ViewComponent
    {
        private readonly IStoryVideoService _storyVideoService;

        public _DefaultStoryVideoComponentPartial(IStoryVideoService storyVideoService)
        {
            _storyVideoService = storyVideoService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _storyVideoService.GetAllStoryVideoAsync();
            return View(values);
        }
    }
}
