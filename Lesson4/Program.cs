using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Lesson4.Data;
using Microsoft.EntityFrameworkCore.Design;
using Lesson4.Models;
using System.Collections.Generic;

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
                //StartMigration(context);
                //StartInitialize(context);

                WriteConsoleTablesData(context);
            }

            Console.ReadLine();
        }

        static void StartMigration(DatabaseContext context)
        {
            Console.WriteLine("Process migration");
            context.Database.Migrate();
            Console.WriteLine("End migration");
        }

        static void StartInitialize(DatabaseContext context)
        {
            Console.WriteLine("Process initialization");
            DbInitializer.Initialize(context);
            Console.WriteLine("End initialization");
        }

        static void WriteConsoleTablesData(DatabaseContext context)
        {
            Console.WriteLine("ALL Data tables:");
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Table TypeProduct:");
            WriteConsoleTableData(context.TypeProducts.ToList());
            Console.WriteLine("Table TypeAnnouncements:");
            WriteConsoleTableData(context.TypeAnnouncements.ToList());
            Console.WriteLine("Table Persons:");
            WriteConsoleTableData(context.Persons.ToList());
            Console.WriteLine("Table Products:");
            WriteConsoleTableData(context.Products.ToList());
            Console.WriteLine("Table Announcements:");
            WriteConsoleTableData(context.Announcements.ToList());
        }

        static void WriteConsoleTableData<T>(List<T> dataTable)
        {
            Console.WriteLine(new string('-', 20));
            foreach (var item in dataTable)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 20));
        }
    }
}