using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TinTucCTSV.Data.Interfaces;
using TinTucCTSV.Data.Models;
using TinTucCTSV.Models.Form;

namespace TinTucCTSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Administrator")]
    public class FormController : Controller
    {
        private readonly IForm _formService;
        public FormController(IForm formService){
            _formService = formService;
        }
        
        public IActionResult Index(){
            var forms = _formService.GetAll()
                .Select(f => new FormViewModel{
                    Id = f.Id,
                    Title = f.Title,
                    Created = f.Created,
                    LinkUrl = f.LinkUrl
                });
            var model = new FormIndexModel{
                listForms = forms
            };
            return View(model);
        }

        public IActionResult Create(){
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateForm(FormNewModel model){
            if (ModelState.IsValid)
            {
                Form form = new Form{
                    Title = model.Title,
                    Created = DateTime.Now,
                    LinkUrl = model.LinkUrl
                };
                await _formService.Add(form);
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Create));
        }

        public IActionResult Update(int? Id){
            if(Id == null){
                return NotFound();
            }
            var formid = _formService.GetById(Id);
            if (formid == null)
            {
                return NoContent();
            }
            var model = new FormUpdateModel{
                Id = formid.Id,
                Title = formid.Title,
                LinkUrl = formid.LinkUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateForm(FormUpdateModel model){
            if (ModelState.IsValid)
            {
                await _formService.Update(model.Id,
                model.LinkUrl);
                
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Update));
        }
        public async Task<IActionResult> Delete(int? Id){
            if (Id ==null)
            {
                NotFound();
            }
            await _formService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}