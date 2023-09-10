using Entities;
using Microsoft.EntityFrameworkCore;

namespace NetCoreWebApp1.Data
{
    // FOR VERSION BEFORE .NET 6
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DatabaseContext>();
            
            context.Database.Migrate();

            if (!context.Database.GetPendingMigrations().Any())
            {

                if (context.Users.Any()) return;

                User user = new()
                {
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    Name = "Admin",
                    Password = "123456",
                    Username = "Admin",
                    Email = "admin@NetCoreWebApp1.net"
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
