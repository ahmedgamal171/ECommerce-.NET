using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context=app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
          if (context.Products.Any()) // Optional: Only remove if there are products in the table
            {
                var allProducts = context.Products.ToList();
                context.Products.RemoveRange(allProducts);  // Removes all products
                context.SaveChanges();  // Apply changes to the database
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name= "Sports t-shirt",
                        Description= "Water Proof t-shirt Blue and Red",
                        Category="Men",
                        Price=50,
                        Image= "https://wayupsports.com/cdn/shop/products/120044_Siux_1.jpg?v=1679406209&width=800"
                    },
                    new Product
                    {
                        Name = "Nike Short",
                        Description = "Black shorts",
                        Category = "Men",
                        Price = 50m,
                        Image= "https://wayupsports.com/cdn/shop/products/DJ6312-010_Nike_2.jpg?v=1676411337&width=800"

                    },
                     new Product
                     {
                         Name = "Sports Leggings",
                         Description = "Purple and white",
                         Category = "Women",
                         Price = 30m,
                         Image= "https://wayupsports.com/cdn/shop/products/WTLG-158-T3-015-S-BLK.jpg?v=1704881760&width=800"

                     },
                     new Product
                     {
                         Name = "Soccer Ball",
                         Description = "Give your playing field a professional touch",
                         Category = "Equipments",
                         Price = 80m,
                         Image= "https://wayupsports.com/cdn/shop/files/IP1639_1_HARDWARE_Photography_Front_Center_View_grey_55316402-9576-4bb1-9962-cd8f2c6648c9.jpg?v=1715172386&width=800"
                     },
                     new Product
                     {
                         Name = "Corner Flags",
                         Description = "4 Corner flags",
                         Category = "Equipments",
                         Price = 200m,
                         Image= "https://i.ebayimg.com/images/g/Zz8AAOSw3VFnTISe/s-l1600.webp"
                     },
                     new Product
                     {
                         Name = "Small Soccer Goal",
                         Description = "Small Soccer Goal",
                         Category = "Equipments",
                         Price = 400,
                         Image= "https://contents.mediadecathlon.com/p2697525/1cr1/k$896dbb6d49e6638eaa9624eadb9a985d/-sg-500-m-slash.jpg?format=auto&f=768x0"
                     },
                     new Product
                     {
                         Name = "Woman Sports t-shirt",
                         Description = "Pink",
                         Category = "Women",
                         Price = 60m,
                         Image= "https://athleshe.com/cdn/shop/files/IMAGE-EDIT_5e16232a-cf40-455b-a5bc-8e04b07e4c4c_2000x.png?v=1725177605"
                     },
                     new Product
                     {
                         Name = "Human Chess Board",
                         Description = "A fun game for the family",
                         Category = "Equipments",
                         Price = 75,
                         Image= "https://i.ebayimg.com/images/g/qecAAOSw4QdkP6ll/s-l960.webp"
                     },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Equipments",
                        Price = 1200,
                        Image= "https://i.ebayimg.com/images/g/qecAAOSw4QdkP6ll/s-l960.webp"
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
