using Core.Entities;
using Intrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intrastructure.Data
{
    public class MenuContext: DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {
        }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MenuContext>
        {
            public MenuContext CreateDbContext(string[] args)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<MenuContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new MenuContext(builder.Options);
            }
        }
    }
}
