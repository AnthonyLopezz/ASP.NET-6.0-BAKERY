using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Models;

namespace DarsBakeryv3.Data.Services
{
    public class PortionService: EntityBaseRepository<Portion>, IPortionService
    {
        public PortionService(ApplicationDbContext context) : base(context) { }
    }
}
