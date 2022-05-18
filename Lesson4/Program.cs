using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Lesson4.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace Lesson4
{
    class Program : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString(name: "DefaultConnection");
            if (connectionString == null)
            {
                throw new Exception("Connection string is null");
            }

            var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionBuilder.UseNpgsql(connectionString);

            return new DatabaseContext(optionBuilder.Options);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            using (var context = p.CreateDbContext(null))
            {
                Console.WriteLine("Process migration");
                context.Database.Migrate();
                Console.WriteLine("End migration");
                Console.WriteLine("Process initialization");
                DbInitializer.Initialize(context);
                Console.WriteLine("End initialization");
            }
        }
    }
}