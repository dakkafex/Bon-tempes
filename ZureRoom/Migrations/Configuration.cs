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

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Admin" };

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

            if (!context.Users.Any(u => u.UserName == "Cook"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "Cook" };

                manager.Create(user, "Pass2!");
                manager.AddToRole(user.Id, "Cook");
            }
        }
    }
}
