using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAssetTrackingV2
{
    internal class AssetDbContext : DbContext
    {
        //string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AssetTracking2;Trusted_Connection=True";
        // Server=localhost;Database=master;Trusted_Connection=True;
        // C:\Program Files\Microsoft SQL Server\170\Setup Bootstrap\Log\20260122_143046
        // C:\SQL2025\StdDev_ENU
        // C:\Program Files\Microsoft SQL Server\170\SSEI\Resources
        string connectionString = "Server=localhost;Database=AssetTracking2;Trusted_Connection=True;TrustServerCertificate=True";

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // We tell the app to use the connectionstring.
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer(connectionString, sql => sql.CommandTimeout(120));
        }


        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {

        }
    }
}
