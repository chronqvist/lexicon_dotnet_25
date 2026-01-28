using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiWorldCities.Models;

namespace WebApiWorldCities.Data
{
    public class WebApiWorldCitiesContext : DbContext
    {
        public WebApiWorldCitiesContext (DbContextOptions<WebApiWorldCitiesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiWorldCities.Models.WorldCity> WorldCity { get; set; } = default!;
    }
}
