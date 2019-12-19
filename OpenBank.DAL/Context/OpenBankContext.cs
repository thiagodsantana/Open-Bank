using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenBank.DAL.Context
{
    public class OpenBankContext:  DbContext
    {
        public IConfiguration Configuration { get; }

        public OpenBankContext(DbContextOptions<OpenBankContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var implementedConfigTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.IsAbstract
                            && !t.IsGenericTypeDefinition
                            && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
                                i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in implementedConfigTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AppLocalContext"));
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);

            return base.SaveChanges();
        }
    }
}
