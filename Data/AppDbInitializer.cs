using DarsBakeryv3.Data.Enum;
using DarsBakeryv3.Data.Static;
using DarsBakeryv3.Models;
using Microsoft.AspNetCore.Identity;

namespace DarsBakeryv3.Data
{
    public class AppDbInitializer
    {
        
        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();

                // Roles
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                if (await roleManager.FindByNameAsync(UserRoles.Admin) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (await roleManager.FindByNameAsync(UserRoles.User) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }

                // Users
                string email = "anthony.lopez@usantoto.edu.co";
                string password = "Dars.B4kery";
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                if (await userManager.FindByNameAsync(email) == null)
                {
                    var user = new IdentityUser()
                    {
                        UserName = email,
                        Email = email,
                        PhoneNumber = "6087440404",
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(user, password);
                        await userManager.AddToRoleAsync(user, UserRoles.Admin);
                    }
                }
                email = "anthony@gmail.co";
                if (await userManager.FindByNameAsync(email) == null)
                {
                    var user = new IdentityUser()
                    {
                        UserName = email,
                        Email = email,
                        PhoneNumber = "6087440404",
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(user);
                    if (result.Succeeded)
                    {
                        await userManager.AddPasswordAsync(user, password);
                        await userManager.AddToRoleAsync(user, UserRoles.User);
                    }
                }
            }
        }

        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                //Employee
                if (!context.Employee.Any())
                {
                    context.Employee.AddRange(new List<Employee>() {
                 new Employee()
                        {
                        Name = "Andrew Boston",
                        DNI = "123456789",
                        PhoneNumber = "+0987654321",
                        Photo = "http://localhost/img/darsBakery/Employee/Employee1.jpg",
                        RoleJob = RoleJob.Cashier
                        },
                 new Employee()
                        {
                        Name = "Mathew Brown",
                        DNI = "123456789",
                        PhoneNumber = "+0987654321",
                        Photo = "http://localhost/img/darsBakery/Employee/Employee2.jpg",
                        RoleJob = RoleJob.Chef

                        },
                 new Employee()
                        {
                        Name = "Elona Watson",
                        DNI = "123456789",
                        PhoneNumber = "+0987654321",
                        Photo = "http://localhost/img/darsBakery/Employee/Employee3.jpg",
                        RoleJob = RoleJob.Waiter
                        },
                 new Employee()
                        {
                        Name = "Anthony López",
                        DNI = "123456789",
                        PhoneNumber = "+0987654321",
                        Photo = "",
                        RoleJob = RoleJob.Chef

                        },

                });
                    context.SaveChanges();
                }

                //Frosting
                if (!context.Frosting.Any())
                {
                    context.Frosting.AddRange(new List<Frosting>() {
                 new Frosting()
                        {
                        Name = "Chantilly",
                        },
                 new Frosting()
                        {
                        Name = "Chocolate",
                        },
                 new Frosting()
                        {
                        Name = "Fondant",
                        },
                 new Frosting()
                        {
                        Name = "Merengue",
                        },
                 new Frosting()
                        {
                        Name = "Ganache",
                        },

                });
                    context.SaveChanges();
                }

                //Flavor
                if (!context.Flavor.Any())
                {
                    context.Flavor.AddRange(new List<Flavor>() {
                 new Flavor()
                        {
                        Name = "Vainilla",
                        },
                 new Flavor()
                        {
                        Name = "Chocolate",
                        },
                 new Flavor()
                        {
                        Name = "Oreo",
                        },
                 new Flavor()
                        {
                        Name = "Carrot",
                        },
                 new Flavor()
                        {
                        Name = "Coffe",
                        },

                });
                    context.SaveChanges();
                }

                //Portions
                if (!context.Portion.Any())
                {
                    context.Portion.AddRange(new List<Portion>() {
                 new Portion()
                        {
                        Name = "8 a 10 portions",
                        },
                 new Portion()
                        {
                        Name = "12 a 14 portions",
                        },
                 new Portion()
                        {
                        Name = "16 a 18 portions",
                        },
                 new Portion()
                        {
                        Name = "25 a 28 portions",
                        },
                 new Portion()
                        {
                        Name = "45 a 50 portions",
                        },

                });
                    context.SaveChanges();
                }

                //Cakes
                if (!context.Cake.Any())
                {
                    context.Cake.AddRange(new List<Cake>()
                    {
                        new Cake()
                        {
                            Name = "Coffe Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/CoffeCake.webp",
                            FrostingId = 1,
                            PortionId = 1,
                            FlavorId = 1,
                            Shape = Shape.Circle
                        },

                        new Cake()
                        {
                            Name = "Snickers Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/SnickersCake.webp",
                            FrostingId = 1,
                            PortionId = 1,
                            FlavorId = 1,
                            Shape = Shape.Circle

                        },

                        new Cake()
                        {
                            Name = "Birthday Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/birthdayCake.webp",
                            FrostingId = 1,
                            PortionId = 1,
                            FlavorId = 1,
                            Shape = Shape.Circle
                        },

                        new Cake()
                        {
                            Name = "Carrot Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/carrotCake.webp",
                            FrostingId = 1,
                            PortionId = 1,
                            FlavorId = 1,
                            Shape = Shape.Circle

                        },

                        new Cake()
                        {
                            Name = "Chocolate Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/chocolateCake.webp",
                            FrostingId = 1,
                            PortionId =1,
                            FlavorId = 1,
                            Shape = Shape.Circle
                        },

                        new Cake()
                        {
                            Name = "Choco Berries Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/chocoBerriesCake.webp",
                            FrostingId = 1,
                            PortionId = 1,
                            FlavorId = 1,
                            Shape = Shape.Circle

                        },

                        new Cake()
                        {
                            Name = "Kinder Cake",
                            Price = 41000,
                            ImageURL = "http://localhost/img/darsBakery/Cakes/KinderCake.webp",
                            FrostingId = 1,
                            PortionId = 1,
                            FlavorId = 1,
                            Shape = Shape.Circle

                        }
                    });
                    context.SaveChanges();

                }


            }
        }
    }
}
