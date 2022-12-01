using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Models;

namespace DarsBakeryv3.Data.Services
{
    public class FrostingService: EntityBaseRepository<Frosting>, IFrostingService
    {
        public FrostingService(ApplicationDbContext context) : base(context) { }
    }
}
