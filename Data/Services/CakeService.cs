using DarsBakeryv3.Data.Base;
using DarsBakeryv3.Data.ViewModels;
using DarsBakeryv3.Models;
using Microsoft.EntityFrameworkCore;

namespace DarsBakeryv3.Data.Services
{
    public class CakeService: EntityBaseRepository<Cake>, ICakeService
    {
        
        private readonly ApplicationDbContext _context;
        public CakeService(ApplicationDbContext context) : base(context) {
            _context = context;
        }
        
        public async Task AddNewCakeAsync(NewCakeVM data)
        {
            var newCake = new Cake()
            {
                Name = data.Name,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Shape = data.Shape,
                PortionId = data.PortionId,
                FlavorId = data.FlavorId,
                FrostingId = data.FrostingId,
            };
            await _context.Cake.AddAsync(newCake);
            await _context.SaveChangesAsync();
        }

        public async Task<Cake> GetCakeByIdAsync(int id)
        {
            var cakeDetails = await _context.Cake
                .Include(c => c.Flavor)
                .Include(p => p.Portion)
                .Include(p => p.Frosting)
                .FirstOrDefaultAsync(n => n.Id == id);

            return cakeDetails;
        }

        public async Task<NewCakeDropdownsVM> GetNewCakeDropdownsValues()
        {
            var response = new NewCakeDropdownsVM()
            {
                Portions = await _context.Portion.OrderBy(n => n.Name).ToListAsync(),
                Flavors = await _context.Flavor.OrderBy(n => n.Name).ToListAsync(),
                Frostings = await _context.Frosting.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateCakeAsync(NewCakeVM data)
        {
            var dbCake = await _context.Cake.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbCake != null)
            {
                dbCake.Name = data.Name;
                dbCake.Price = data.Price;
                dbCake.ImageURL = data.ImageURL;
                dbCake.Shape = data.Shape;
                dbCake.PortionId = data.PortionId;
                dbCake.FlavorId = data.FlavorId;
                dbCake.FrostingId = data.FrostingId;
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }

    }
}
