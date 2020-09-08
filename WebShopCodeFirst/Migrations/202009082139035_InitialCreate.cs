namespace WebShopCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        ActionName = c.String(),
                        ActionDescription = c.String(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.ActionId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        Region = c.String(),
                        PostalCode = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Currancies",
                c => new
                    {
                        CurrancyId = c.Int(nullable: false, identity: true),
                        CurrancyName = c.String(),
                        CurrancyCode = c.String(),
                    })
                .PrimaryKey(t => t.CurrancyId);
            
            CreateTable(
                "dbo.Licences",
                c => new
                    {
                        LicenceId = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LicenceId);
            
            CreateTable(
                "dbo.OrderDetaills",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        LicanceId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                        Licence_LicenceId = c.Int(),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Licences", t => t.Licence_LicenceId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.Licence_LicenceId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CurrancyId = c.Int(nullable: false),
                        ShippedDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShipAddress = c.String(),
                        OrderStatus = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Currancies", t => t.CurrancyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.CurrancyId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        AddressId = c.Int(nullable: false),
                        Telephone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleDescription = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        HaveDiscount = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDigital = c.Boolean(nullable: false),
                        IsService = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductLocations",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WarehouseId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.WarehouseId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        WarehouseName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WarehouseId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductLocations", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Warehouses", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ProductLocations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetaills", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.OrderDetaills", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Actions", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "CurrancyId", "dbo.Currancies");
            DropForeignKey("dbo.OrderDetaills", "Licence_LicenceId", "dbo.Licences");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.Warehouses", new[] { "AddressId" });
            DropIndex("dbo.ProductLocations", new[] { "ProductId" });
            DropIndex("dbo.ProductLocations", new[] { "WarehouseId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Users", new[] { "AddressId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "User_UserId" });
            DropIndex("dbo.Orders", new[] { "CurrancyId" });
            DropIndex("dbo.OrderDetaills", new[] { "Licence_LicenceId" });
            DropIndex("dbo.OrderDetaills", new[] { "ProductId" });
            DropIndex("dbo.OrderDetaills", new[] { "OrderId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropIndex("dbo.Actions", new[] { "Role_RoleId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.ProductLocations");
            DropTable("dbo.Products");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetaills");
            DropTable("dbo.Licences");
            DropTable("dbo.Currancies");
            DropTable("dbo.Categories");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
            DropTable("dbo.Actions");
        }
    }
}
