﻿using API_Versioning.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Versioning.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
