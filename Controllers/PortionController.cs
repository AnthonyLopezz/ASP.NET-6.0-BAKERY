using DarsBakeryv3.Data.Services;
using DarsBakeryv3.Data.Static;
using DarsBakeryv3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DarsBakeryv3.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class PortionController : Controller
    {
        private readonly IPortionService _service;

        public PortionController(IPortionService service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var allPortion = await _service.GetAllAsync();
            return View(allPortion);
        }

        //GET: Portion/details/1
        
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //GET: Portion/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Portion portion)
        {
            if (!ModelState.IsValid) return View(portion);

            await _service.AddAsync(portion);
            return RedirectToAction(nameof(Index));
        }

        //GET: Portion/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Portion portion)
        {
            if (!ModelState.IsValid) return View(portion);

            if (id == portion.Id)
            {
                await _service.UpdateAsync(id, portion);
                return RedirectToAction(nameof(Index));
            }
            return View(portion);
        }

        //GET: Portion/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
