namespace Repository.Migrations
{
    using Repository.Models.Products;
    using Repository.Models.Users;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Context.WebShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Repository.Context.WebShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Roles.AddOrUpdate(x => x.RoleId,
            //    new Role() { RoleId = 1, RoleName = "Admin" },
            //    new Role() { RoleId = 2, RoleName = "Finance" },
            //    new Role() { RoleId = 3, RoleName = "Customer" },
            //    new Role() { RoleId = 4, RoleName = "Miguel de Cervantes" }
            //);

            //context.Countries.AddOrUpdate(x => x.CountryId,
            //    new Country() { CountryName = "Serbia", CountryCode = "SRB", IsActive = true },
            //    new Country() { CountryName = "North Macedonia", CountryCode = "NMC", IsActive = true }
            //);

            //context.Addresses.AddOrUpdate(x => x.AddressId,
            //    new Address() { City = "Nis", Street = "Zaplanjska 18", StreetNumber = "18", Region = "Nisavski", PostalCode = "18110", CountryId = 1 },
            //    new Address() { City = "Nis", Street = "Mokranjceva", StreetNumber = "20", Region = "Nisavski", PostalCode = "18100", CountryId = 1 },
            //    new Address() { City = "Nis", Street = "Nisavska", StreetNumber = "54", Region = "Nisavski", PostalCode = "18100", CountryId = 1 }
            //);

            //context.Users.AddOrUpdate(x => x.RoleId,
            //    new User() { FirstName = "Nemanja", LastName = "Nikolic", Age = 29, RoleId = 1, Username = "nexencode", Email = "nexencode@gmail.com", Password = "coding", AddressId = 3, Telephone = "12345", IsActive = true },
            //    new User() { FirstName = "Marko", LastName = "Kozic", Age = 35, RoleId = 1, Username = "markocode", Email = "markocode@gmail.com", Password = "coding", AddressId = 4, Telephone = "12345", IsActive = true },
            //    new User() { FirstName = "Darko", LastName = "Crnic", Age = 27, RoleId = 1, Username = "darkocode", Email = "darkocode@gmail.com", Password = "coding", AddressId = 5, Telephone = "12345", IsActive = true }
            //);
            //context.Categories.AddOrUpdate(x => x.CategoryId,
            //    new Category() { CategoryDescription = "Mobilni Telefoni"}
            //);

            //context.Products.AddOrUpdate(x => x.CategoryId,
            //    new Product("Xiaomi MI 10 Pro", "Tthe cites of the word in classical literature.", 550, 10, true, true, true, false, 1)
            //);


        }
    }
}
