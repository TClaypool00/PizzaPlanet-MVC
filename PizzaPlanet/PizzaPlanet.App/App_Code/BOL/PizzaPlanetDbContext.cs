﻿using Microsoft.EntityFrameworkCore;

namespace PizzaPlanet.App.App_Code.BOL
{
    public class PizzaPlanetDbContext : DbContext
    {
        public PizzaPlanetDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(SecretConfig.ConnectionString, new MySqlServerVersion(SecretConfig.Version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsAdmin)
                .HasDefaultValue(false);
            });
        }
    }
}
