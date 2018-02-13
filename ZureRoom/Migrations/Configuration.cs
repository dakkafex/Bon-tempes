namespace ZureRoom.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZureRoom.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZureRoom.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZureRoom.Models.ApplicationDbContext context)
        {
            //Admin
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@bt.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@bt.com" };

                manager.Create(user, "Pass1!");
                manager.AddToRole(user.Id, "Admin");
            }

            //Kok
            if (!context.Roles.Any(r => r.Name == "Cook"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Cook" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "cook@bt.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "cook@bt.com" };

                manager.Create(user, "Pass2!");
                manager.AddToRole(user.Id, "Cook");
            }

            //tafels
            if (!context.Tafels.Any(s => s.TableNmr == 1))
            {
                context.Tafels.AddOrUpdate(x => x.Id,
                    new Models.Tafel()
                    {
                        Id = 1,
                        TableNmr = 1,
                        Chairs = 4
                    },
                    new Models.Tafel()
                    {
                        Id = 2,
                        TableNmr = 2,
                        Chairs = 6
                    },
                    new Models.Tafel()
                    {
                        Id = 3,
                        TableNmr = 3,
                        Chairs = 8
                    },
                    new Models.Tafel()
                    {
                        Id = 4,
                        TableNmr = 4,
                        Chairs = 4
                    },
                    new Models.Tafel()
                    {
                        Id = 5,
                        TableNmr = 5,
                        Chairs = 6
                    });
            }
            //Menu
            if (!context.Menus.Any(s => s.Name == "TestMenu"))
            {
                context.Menus.AddOrUpdate(x => x.ID,
                new Menu()
                {
                    ID = 1,
                    Name = "TestMenu",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Nuts = true,
                    Shellfish = false,
                    Soy = true,
                    Eggs = false,
                    Milk = true,
                    Price = 9.99M
                },
                new Menu()
                {
                    ID = 2,
                    Name = "TestMenu2",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Nuts = false,
                    Shellfish = false,
                    Soy = false,
                    Eggs = true,
                    Milk = false,
                    Price = 9.99M
                });
            }

            //Reservation
            context.Reservations.AddOrUpdate(x => x.ID,
            new Reservation()
            {
                ID = 1,
                MenuName = "TestMenu1",
                Amount = 5,
                Name = "TestNaam1",
                Email = "TestMail1",
                Phone = "1234567890",
                Size = 5,
                Price = 9.99M,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Date = DateTime.ParseExact("05/02/2018 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
            },
            new Reservation()
            {
                ID = 2,
                MenuName = "TestMenu1",
                Amount = 5,
                Name = "TestNaam2",
                Email = "TestMail2",
                Phone = "1234567890",
                Size = 5,
                Price = 4.99M,
                Message = "Lorem ipsum dolor sit amet",
                Date = DateTime.ParseExact("05/02/2018 12:00:00", "dd/MM/yyyy HH:mm:ss", null)
            });

            //Contact
            context.Contacts.AddOrUpdate(x => x.ID,
            new Contact()
            {
                ID = 1,
                Name = "TestNaam1",
                Email = "TestMail1",
                Phone = "1234567890"
            },
            new Contact()
            {
                ID = 2,
                Name = "TestNaam2",
                Email = "TestMail2",
                Phone = "0987654321"
            },
            new Contact()
            {
                ID = 3,
                Name = "TestNaam3",
                Email = "TestMail3",
                Phone = "1111111111"
            });
        }
    }
}