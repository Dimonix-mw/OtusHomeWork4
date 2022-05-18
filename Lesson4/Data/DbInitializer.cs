using Lesson4.Models;

namespace Lesson4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            //Look for any Product
            if (context.Products.Any())
            {
                return; // DB was filled
            }

            using (var transaction = context.Database.BeginTransaction())
            {

                //add data to TypeProducts table
                foreach (var item in Enum.GetValues(typeof(TypeProductEnum)))
                {
                    context.TypeProducts.Add(new TypeProduct { Type = (TypeProductEnum)item });
                }
                context.SaveChanges();

                //add data to TypeAnnouncement table
                foreach (var item in Enum.GetValues(typeof(TypeAnnouncementEnum)))
                {
                    context.TypeAnnouncements.Add(new TypeAnnouncement { Type = (TypeAnnouncementEnum)item });
                }
                context.SaveChanges();

                //add data to Persons table
                Person[] persons = new Person[]
                {
                new Person{ FirstName = "Dmitriy", LastName = "Ivanov", Email = "123@mail.ru", PhoneNumber = "+7921222245"},
                new Person{ FirstName = "Alex",    Email = "teas@mail.ru", PhoneNumber = "+75555567"},
                new Person{ FirstName = "Fedor", LastName = "Maxsimov", Email = "fmax@yandex.ru", PhoneNumber = "+778944565"},
                new Person{ FirstName = "Polina", LastName = "Mihailova", Email = "mixP@rambler.ru", PhoneNumber = "+79287775554"},
                new Person{ FirstName = "Maxim", Email = "123@mail.ru", PhoneNumber = "+7921222245"},
                };
                context.Persons.AddRange(persons);
                context.SaveChanges();

                //add data to Products table
                Product[] products = new Product[]
                {
                new Product { Name = "BMW M6", Description = "very cool", Price = 4500000, TypeProductId = 4},
                new Product { Name = "Mersedes 123", Description = "cool", Price = 1200000, TypeProductId = 4},
                new Product { Name = "House 100m", Description = "nice", Price = 5500000, TypeProductId = 2},
                new Product { Name = "Flat 95m", Price = 4700000, TypeProductId = 3},
                new Product { Name = "Flat 70m", Description = "the best", Price = 25000, TypeProductId = 3}
                };
                context.Products.AddRange(products);
                context.SaveChanges();

                //add data to Announcements table
                Announcement[] announcements = new Announcement[]
                {
                new Announcement{ PersonId = 2, ProductId = 2, Title = "Sale car", TypeAnnouncementId = 2},
                new Announcement{ PersonId = 3, ProductId = 3, Title = "Sale car", TypeAnnouncementId = 2},
                new Announcement{ PersonId = 4, ProductId = 4, Title = "Sale house", TypeAnnouncementId = 2},
                new Announcement{ PersonId = 5, ProductId = 5, Title = "Sale flat", TypeAnnouncementId = 2},
                new Announcement{ PersonId = 6, ProductId = 6, Title = "Rent flat", TypeAnnouncementId = 4},
                };
                context.Announcements.AddRange(announcements);
                context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
