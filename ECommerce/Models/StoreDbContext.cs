﻿using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
