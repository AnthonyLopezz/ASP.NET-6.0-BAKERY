using DarsBakeryv3.Data.Services;
using DarsBakeryv3.Data.Static;
using DarsBakeryv3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DarsBakeryv3.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class FrostingController : Controller
    {
        private readonly IFrostingService _service;

        public FrostingController(IFrostingService service)
        {
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var allFrosting = await _service.GetAllAsync();
            return View(allFrosting);
        }

        //GET: Frosting/details/1
        
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //GET: Frosting/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Frosting frosting)
        {
            if (!ModelState.IsValid) return View(frosting);

            await _service.AddAsync(frosting);
            return RedirectToAction(nameof(Index));
        }

        //GET: Frosting/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Frosting frosting)
        {
            if (!ModelState.IsValid) return View(frosting);

            if (id == frosting.Id)
            {
                await _service.UpdateAsync(id, frosting);
                return RedirectToAction(nameof(Index));
            }
            return View(frosting);
        }

        //GET: Frosting/delete/1
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
