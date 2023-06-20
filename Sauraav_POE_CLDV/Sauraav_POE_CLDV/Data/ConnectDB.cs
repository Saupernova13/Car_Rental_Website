﻿using Microsoft.EntityFrameworkCore;
using Sauraav_POE_CLDV.Models;
namespace Sauraav_POE_CLDV.Data
{
    public class ConnectDB : DbContext
    {
        public ConnectDB(DbContextOptions options) : base(options)
        {
        }
        public DbSet<carBodyTypeModel> carBodyType { get; set; }
        public DbSet<carMakeModel> carMake { get; set; }
        public DbSet<carTableModel> car { get; set; }
        public DbSet<driverModel> driver { get; set; }
        public DbSet<inspectorModel> inspector { get; set; }
        public DbSet<rentalModel> rental { get; set; }
        public DbSet<returnTableModel> returnTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<carBodyTypeModel>()
                .HasKey(c => c.carBodyTypeID);
            modelBuilder.Entity<carMakeModel>()
                .HasKey(c => c.carMakeID);
            modelBuilder.Entity<carTableModel>()
                .HasKey(c => c.carNo);
            modelBuilder.Entity<driverModel>()
                .HasKey(c => c.driverID);
            modelBuilder.Entity<inspectorModel>()
                .HasKey(c => c.inspectorNo);
            modelBuilder.Entity<rentalModel>()
                .HasKey(c => c.rentalID);
            modelBuilder.Entity<returnTableModel>()
                .HasKey(c => c.returnID);
        }
    }
}