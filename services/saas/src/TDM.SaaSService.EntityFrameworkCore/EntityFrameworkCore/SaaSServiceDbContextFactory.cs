using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDM.SaaSService.EntityFrameworkCore
{
    public class SaaSServiceDbContextFactory : IDesignTimeDbContextFactory<SaaSServiceDbContext>
    {
        public SaaSServiceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SaaSServiceDbContext>()
                .UseSqlServer(GetConnectionStringFromConfiguration());

            return new SaaSServiceDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(SaaSServiceDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent!.FullName!,
                        $"host{Path.DirectorySeparatorChar}TDM.SaaSService.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }
}
