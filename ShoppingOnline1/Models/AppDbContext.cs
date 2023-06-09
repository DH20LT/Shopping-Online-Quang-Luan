﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ShoppingOnline1.Models.Orders;
using ShoppingOnline1.Models.Carts;
using ShoppingOnline1.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;

namespace ShoppingOnline1.Models;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Thiết lập model dùng để tạo DB
    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }
    // Thiết lập model dùng để tạo DB

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<OrderDetail>().HasKey(od => new {od.OrderId, od.ProductId});

        modelBuilder.Ignore<CartItem>();

        // Make add Migration work
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.UserId });
        modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId });
        modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => new { x.UserId, x.Value });
        // Make add Migration work

    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlite(
                "Data Source=" +
                       Path.Combine(Directory.GetCurrentDirectory(), "mydb.db")
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}