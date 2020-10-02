using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }



        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
          {
              builder
                   .AddFilter((category, level) =>
                       category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information)
                   .AddConsole();
          });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer(
                 "Server = (localdb)\\mssqllocaldb; Database = SamuraiAppDataCore-2; Trusted_Connection = True; ")
                .EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.SamuraiId, s.BattleId }); 
            
           // base.OnModelCreating(modelBuilder);
        }
    }
}
