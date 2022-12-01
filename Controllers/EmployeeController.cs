using DarsBakeryv3.Data.Services;
using DarsBakeryv3.Data.Static;
using DarsBakeryv3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DarsBakeryv3.Controllers
{
    //[Authorize(Roles = UserRoles.Admin)]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allEmployee = await _service.GetAllAsync();
            return View(allEmployee);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Team()
        {
            var allEmployee = await _service.GetAllAsync();
            return View(allEmployee);
        }

        //GET: Employee/details/1
        public async Task<IActionResult> Details(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        //GET: Employee/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Photo, DNI, PhoneNumber, RoleJob")] Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);

            await _service.AddAsync(employee);
            return RedirectToAction(nameof(Index));
        }

        //GET: Employee/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var details = await _service.GetByIdAsync(id);
            if (details == null) return View("NotFound");
            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, Photo, DNI, PhoneNumber, RoleJob")] Employee employee)
        {
            if (!ModelState.IsValid) return View(employee);

            if (id == employee.Id)
            {
                await _service.UpdateAsync(id, employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        //GET: Employee/delete/1
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
