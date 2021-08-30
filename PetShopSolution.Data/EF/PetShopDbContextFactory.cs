using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetShopSolution.Data.EF
{
    public class PetShopDbContextFactory : IDesignTimeDbContextFactory<PetShopDbContext>
    {
        public PetShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("PetShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<PetShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new PetShopDbContext(optionsBuilder.Options);
        }
    }
}
