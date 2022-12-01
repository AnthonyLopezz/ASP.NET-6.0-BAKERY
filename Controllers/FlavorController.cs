using DarsBakeryv3.Data.Services;
using DarsBakeryv3.Data.Static;
using DarsBakeryv3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DarsBakeryv3.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]

    public class FlavorController : Controller
    {
        private readonly IFlavorService _service;

        public FlavorController(IFlavorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allFlavor = await _service.GetAllAsync();
            return View(allFlavor);
        }

        //GET: Flavor/details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //GET: Flavor/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Flavor flavor)
        {
            if (!ModelState.IsValid) return View(flavor);

            await _service.AddAsync(flavor);
            return RedirectToAction(nameof(Index));
        }

        //GET: Flavor/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Flavor flavor)
        {
            if (!ModelState.IsValid) return View(flavor);

            if (id == flavor.Id)
            {
                await _service.UpdateAsync(id, flavor);
                return RedirectToAction(nameof(Index));
            }
            return View(flavor);
        }

        //GET: Flavor/delete/1
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
