using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Models;

namespace DarsBakeryv3.Data.Services
{
    public class FlavorService: EntityBaseRepository<Flavor>, IFlavorService
    {
        public FlavorService(ApplicationDbContext context) : base(context) { }
    }
}
