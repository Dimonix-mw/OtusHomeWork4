using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Lesson4.Data;
using Lesson4.Models;

namespace Lesson4
{
    class Program
    {

        static void Main(string[] args)
        {
            var optionBuilder = GetContextOptionsBuilder();
            using (var context = new DatabaseContext(optionBuilder.Options))
            {
                StartMigration(context);
                PrintConsoleSeparator();
                StartInitializationDB(context);
            }

            WriteConcoleMenu();

            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    using (var context = new DatabaseContext(optionBuilder.Options))
                    {
                        WriteConsoleTablesData(context);
                    }
                    WriteConcoleMenu();
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Add person:");
                    Console.Write("Enter first name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    string phoneNumber = Console.ReadLine();

                    if (firstName != null && email != null && phoneNumber != null)
                    {
                        using (var context = new DatabaseContext(optionBuilder.Options))
                        {
                            Person person = new Person()
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Email = email,
                                PhoneNumber = phoneNumber
                            };
                            AddPerson(context, person);
                        }
                    } else
                    {
                        Console.WriteLine("The data did not pass verification try again!");
                    }
                    WriteConcoleMenu();
                }
                else if (answer == "3")
                {
                    break;
                } else
                {
                    Console.WriteLine("Unknown command");
                    WriteConcoleMenu();
                }
            }
        }

        static DbContextOptionsBuilder<DatabaseContext> GetContextOptionsBuilder()
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
            return optionBuilder;
        }

        static void StartMigration(DatabaseContext context)
        {
            Console.WriteLine("Process migration");
            context.Database.Migrate();
            Console.WriteLine("End migration");
        }

        static void StartInitializationDB(DatabaseContext context)
        {
            Console.WriteLine("Process initialization");
            DbInitializer.Initialize(context);
            Console.WriteLine("End initialization");
        }

        static void AddPerson(DatabaseContext context, Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
            Console.WriteLine("Add person complite.");
        }

        static void WriteConcoleMenu()
        {
            PrintConsoleSeparator();
            Console.WriteLine("Menu:");
            PrintConsoleSeparator();
            Console.WriteLine("To output table data, enter 1");
            Console.WriteLine("To add data to a table Person, enter 2");
            Console.WriteLine("To exit, enter 3");
            PrintConsoleSeparator();
            Console.Write("Your choice: ");
        }

        static void WriteConsoleTablesData(DatabaseContext context)
        {
            Console.WriteLine("ALL Data tables:");
            PrintConsoleSeparator();

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
            PrintConsoleSeparator();
            foreach (var item in dataTable)
            {
                Console.WriteLine(item);
            }
            PrintConsoleSeparator();
        }

        static void PrintConsoleSeparator()
        {
            Console.WriteLine(new string('-', 20));
        }
    }
}