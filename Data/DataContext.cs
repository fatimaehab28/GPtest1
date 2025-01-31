﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using tbackendgp.Models;


namespace tbackendgp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<IdentityCard> IdentityCard { get; set; }

        public DbSet<Property> Properties { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.UserTypeId)
                .HasDefaultValue(2);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>()
                .HasIndex(p => p.PropertyName)
                .IsUnique(); // Ensure unique property names if required

            base.OnModelCreating(modelBuilder);
        }

    }
}
