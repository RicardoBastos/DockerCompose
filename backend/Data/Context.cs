using System.IO;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }

    }

    // public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Contexto>
    // {
    //     public Contexto CreateDbContext(string[] args)
    //     {
    //        var configuration = new ConfigurationBuilder()
    //              .SetBasePath(Directory.GetCurrentDirectory())
    //              .AddJsonFile("appsettings.json")
    //              .Build();

    //         var dbContextBuilder = new DbContextOptionsBuilder<Contexto>();

    //         var connectionString = configuration
    //                     .GetConnectionString("DefaultConnection");

    //         dbContextBuilder.UseSqlServer(connectionString);

    //         return new Contexto(dbContextBuilder.Options);
    //     }
    // }
}

//dotnet ef database update