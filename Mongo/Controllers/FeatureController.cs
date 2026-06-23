using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.FeatureDto;
using Mongo.Service.FeatureServices;

namespace Mongo.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto _createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(_createFeatureDto);
            return RedirectToAction("FeatureList");
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("FeatureList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var value = await _featureService.GetFeatureByIdAsync(id);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto _updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(_updateFeatureDto);
            return RedirectToAction("FeatureList");
        }
    }
}
