using DarsBakeryv3.Data.Services;
using DarsBakeryv3.Data.Static;
using DarsBakeryv3.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DarsBakeryv3.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]
    public class CakeController : Controller
    {
        
        private readonly ICakeService _service;

        public CakeController(ICakeService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> IndexDars()
        {
            var allCake = await _service.GetAllAsync();
            return View(allCake);
        }

        public async Task<IActionResult> Index()
        {
            var allCake = await _service.GetAllAsync();
            return View(allCake);
        }

        //Get: Actors/Delete/id

        public async Task<IActionResult> Delete(int id)
        {
            var details = await _service.GetCakeByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var details = await _service.GetCakeByIdAsync(id);
            if (details == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allCake = await _service.GetAllAsync(n => n.Flavor);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allCake.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allCake.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase));

                return View("Index", filteredResultNew);
            }

            return View("Index", allCake);
        }

        //GET: Cake/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetCakeByIdAsync(id);
            return View(details);
        }
        [AllowAnonymous]

        public async Task<IActionResult> Detail(int id)
        {
            var details = await _service.GetCakeByIdAsync(id);
            return View(details);
        }

        //GET: Cake/Create
        public async Task<IActionResult> Create()
        {
            var dropdownsData = await _service.GetNewCakeDropdownsValues();

            ViewBag.Flavors = new SelectList(dropdownsData.Flavors, "Id", "Name");
            ViewBag.Frostings = new SelectList(dropdownsData.Frostings, "Id", "Name");
            ViewBag.Portions = new SelectList(dropdownsData.Portions, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCakeVM cake)
        {
            if (!ModelState.IsValid)
            {
                var dropdownsData = await _service.GetNewCakeDropdownsValues();

                ViewBag.Flavors = new SelectList(dropdownsData.Flavors, "Id", "Name");
                ViewBag.Frostings = new SelectList(dropdownsData.Frostings, "Id", "Name");
                ViewBag.Portions = new SelectList(dropdownsData.Portions, "Id", "Name");

                return View(cake);
            }

            await _service.AddNewCakeAsync(cake);
            return RedirectToAction(nameof(Index));
        }


        //GET: Cake/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cakeDetails = await _service.GetCakeByIdAsync(id);
            if (cakeDetails == null) return View("NotFound");

            var response = new NewCakeVM()
            {
                Id = cakeDetails.Id,
                Name = cakeDetails.Name,
                Price = cakeDetails.Price,
                ImageURL = cakeDetails.ImageURL,
                PortionId = cakeDetails.PortionId,
                FlavorId = cakeDetails.FlavorId,
                FrostingId = cakeDetails.FrostingId
            };

            var dropdownsData = await _service.GetNewCakeDropdownsValues();

            ViewBag.Flavors = new SelectList(dropdownsData.Flavors, "Id", "Name");
            ViewBag.Frostings = new SelectList(dropdownsData.Frostings, "Id", "Name");
            ViewBag.Portions = new SelectList(dropdownsData.Portions, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCakeVM cake)
        {
            if (id != cake.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var dropdownsData = await _service.GetNewCakeDropdownsValues();

                ViewBag.Flavors = new SelectList(dropdownsData.Flavors, "Id", "Name");
                ViewBag.Frostings = new SelectList(dropdownsData.Frostings, "Id", "Name");
                ViewBag.Portions = new SelectList(dropdownsData.Portions, "Id", "Name");

                return View(cake);
            }

            await _service.UpdateCakeAsync(cake);
            return RedirectToAction(nameof(Index));
        } 
    }
}
