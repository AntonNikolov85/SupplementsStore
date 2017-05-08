namespace Store.Data.Migrations
{
    using Models.EntityModels;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StoreDbContext context)
        {
            if (!context.Categories.Any())
            {
                this.AddCategoriesToDb(context);
            }

            if (!context.Suppliers.Any())
            {
                this.AddSuppliersTDb(context);
            }

            if (!context.Products.Any())
            {
                this.AddPhdProducts(context);
                this.AddMpProducts(context);
            }
        }

        private void AddCategoriesToDb(StoreDbContext context)
        {
            Category category = new Category()
            {
                Name = "Pure Protein"
            };
            context.Categories.Add(category);

            category = new Category()
            {
                Name = "Whey Protein"
            };
            context.Categories.Add(category);

            category = new Category()
            {
                Name = "Diet Protein"
            };
            context.Categories.Add(category);

            category = new Category()
            {
                Name = "Pre Workout"
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }

        private void AddSuppliersTDb(StoreDbContext context)
        {
            Supplier supplier = new Supplier()
            {
                Name = "Phd",
                Email = "customersupport@phd.com",
                PhoneNumber = "44-1482-610020",
                Country = "England",
                Town = "Hull, East Yorkshire",
                Address = "Albion Mills Suites 3&4"
            };
            context.Suppliers.Add(supplier);

            supplier = new Supplier()
            {
                Name = "Muslce Pharm",
                Email = "customerservice@musclepharm.com",
                PhoneNumber = "1-800-292-3909",
                Country = "USA",
                Town = "Denver, Colorado",
                Address = "4721 Ironton St."
            };
            context.Suppliers.Add(supplier);
            context.SaveChanges();
        }

        private void AddPhdProducts(StoreDbContext context)
        {
            Product product = new Product()
            {
                Name = "Pharma Whey",
                Description = "Protein powder for muscle mass",
                Url = "~/Content/Images/Phd/Phd_Pharma_Whey.jpg",
                Price = 29.99M,
                IsInStock = true,
                CategoryId = 2,
                SupplierId = 1
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 2).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 1).Products.Add(product);
            context.SaveChanges();

            product = new Product()
            {
                Name = "Synergy ISO7",
                Description = "Protein powder for pure muscle mass and strength",
                Url = "~/Content/Images/Phd/Phd_Synergy_ISO7.jpg",
                Price = 25.99M,
                IsInStock = true,
                CategoryId = 1,
                SupplierId = 1
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 1).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 1).Products.Add(product);
            context.SaveChanges();

            product = new Product()
            {
                Name = "Diet Whey",
                Description = "Protein powder for lean muscles",
                Url = "~/Content/Images/Phd/Phd_Diet_Whey.jpg",
                Price = 19.99M,
                IsInStock = true,
                CategoryId = 3,
                SupplierId = 1
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 3).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 1).Products.Add(product);
            context.SaveChanges();

            product = new Product()
            {
                Name = "Pre Workout Pump",
                Description = "Protein powder for energy and strength",
                Url = "~/Content/Images/Phd/Phd_Synergy_ISO7.jpg",
                Price = 17.99M,
                IsInStock = true,
                CategoryId = 4,
                SupplierId = 1
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 4).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 1).Products.Add(product);
            context.SaveChanges();
        }

        private void AddMpProducts(StoreDbContext context)
        {
            Product product = new Product()
            {
                Name = "Mass Gainer",
                Description = "Protein powder for muscle mass",
                Url = "~/Content/Images/MP/MP_Mass_Gainer.png",
                Price = 34.99M,
                IsInStock = true,
                CategoryId = 2,
                SupplierId = 2
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 2).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 2).Products.Add(product);
            context.SaveChanges();

            product = new Product()
            {
                Name = "Combat Whey",
                Description = "Protein powder for pure muscle mass and strength",
                Url = "~/Content/Images/MP/MP_Combat_Whey.png",
                Price = 30.99M,
                IsInStock = true,
                CategoryId = 1,
                SupplierId = 2
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 1).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 2).Products.Add(product);
            context.SaveChanges();

            product = new Product()
            {
                Name = "Assault Pre Workout",
                Description = "Protein powder for energy and strength",
                Url = "~/Content/Images/MP/MP_Assault_Pre-Wkt.png",
                Price = 21.99M,
                IsInStock = true,
                CategoryId = 4,
                SupplierId = 2
            };
            context.Products.Add(product);
            context.Categories.FirstOrDefault(c => c.Id == 4).Products.Add(product);
            context.Suppliers.FirstOrDefault(s => s.Id == 2).Products.Add(product);
            context.SaveChanges();
        }
    }
}
