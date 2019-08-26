using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Regency;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class RegencyController : Controller
    {
        private readonly IRegency _regencyService;
        public RegencyController(IRegency regencyService){
           _regencyService = regencyService;
        }

        public IActionResult Index(){
            var regencies = _regencyService.GetAll().Select(regency => new RegencyViewModel{
                Id = regency.Id,
                Name = regency.Name,
                Description = regency.Description
            });
            var model = new RegencyIndexModel{
                ListRegencies = regencies
            };
            return View(model);
        }

        //Create Regency
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRegency(RegencyNewModel model){
            if (ModelState.IsValid)
            {
                var regency = new Regency{
                    Name = model.Name,
                    Description = model.Description
                };
                await _regencyService.Add(regency);
            }
            return RedirectToActionPermanent(nameof(Index));
        }

        //Delete Regency
        public async Task<IActionResult> Delete(string Id){
            await _regencyService.Delete(Id);
            return RedirectToActionPermanent(nameof(Index));
        }

        //Edit Regency
        public IActionResult Update(string Id){
            var regency = _regencyService.GetById(Id);
            var result = new RegencyUpdateModel{
                Id = regency.Id,
                Name = regency.Name
            };
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRegency(string Id,RegencyUpdateModel model){
            if (ModelState.IsValid)
            {
                await _regencyService.Edit(Id,model.Name);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToActionPermanent(nameof(Update));
        }
    }
}