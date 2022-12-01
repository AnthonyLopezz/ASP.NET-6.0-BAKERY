using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Models;

namespace DarsBakeryv3.Data.Services
{
    public class EmployeeService: EntityBaseRepository<Employee>, IEmployeeService
    {
        public EmployeeService(ApplicationDbContext context) : base(context) { }
    }
}
