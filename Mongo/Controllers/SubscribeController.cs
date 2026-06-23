using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.SubscribeDto;
using Mongo.Service.SubscribeServices;

namespace Mongo.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }


        public async Task<IActionResult> SubscribeList()
        { 
            var values = await _subscribeService.GetAllSubscribeAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateSubscribe()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            await _subscribeService.CreateSubscribeAsync(createSubscribeDto);
            return RedirectToAction("SubscribeList");
        }


        public async Task<IActionResult> DeleteSubscribe(string id)
        {
            await _subscribeService.DeleteSubscribeAsync(id);
            return RedirectToAction("SubscribeList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSubscribe(string id)
        {
            var value = await _subscribeService.GetSubscribeByIdAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            await _subscribeService.UpdateSubscribeAsync(updateSubscribeDto);
            return RedirectToAction("SubscribeList");
        }   
    }
}
