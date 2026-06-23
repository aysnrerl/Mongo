using Microsoft.AspNetCore.Mvc;
using Mongo.Dtos.SSSDto;
using Mongo.Service.SSSServices;

namespace Mongo.Controllers
{
    public class SSSController : Controller
    {
        private readonly ISSSService _sSSService;

        public SSSController(ISSSService sSSService)
        {
            _sSSService = sSSService;
        }

        public async Task<IActionResult> SSSList()
        {
            var values = await _sSSService.GetAllSSSAsync();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> CreateSSS()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateSSS(CreateSSSDto _createSSSDto)
        {
            await _sSSService.CreateSSSAsync(_createSSSDto);
            return RedirectToAction("SSSList");
        }


        public async Task<IActionResult> DeleteSSS(string id)
        {
            await _sSSService.DeleteSSSAsync(id);
            return RedirectToAction("SSSList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSSS(string id)
        {
            var values = await _sSSService.GetSSSByIdAsync(id);
            var model = new UpdateSSSDto
            {
                SSSId = values.SSSId,
                Question = values.Question,
                Answer = values.Answer,
                Order = values.Order,
                IsActive = values.IsActive
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSSS(UpdateSSSDto _updateSSSDto)
        {
            await _sSSService.UpdateSSSAsync(_updateSSSDto);
            return RedirectToAction("SSSList");
        }
    }
}
