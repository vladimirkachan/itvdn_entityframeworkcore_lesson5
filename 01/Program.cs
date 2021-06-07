using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace _01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using var db = new Context();
            //// Generate(db);
            Console.WriteLine("--- FromSql: #1 ---");
            Console.ReadKey();

            var companies = db.Companies.FromSqlRaw("SELECT * FROM Companies").ToList();
            foreach (var company in companies) Console.WriteLine(company.Name);
            Console.WriteLine("--- FromSql: #2 ---");
            Console.ReadKey();
            var companies2 = db.Companies.FromSqlRaw("SELECT * FROM Companies").OrderBy(x => x.Name).ToList();
            foreach (var company in companies) Console.WriteLine(company.Name);
            Console.WriteLine("--- Finish ---");
            Console.ReadKey();
        }
        static void Generate(Context db)
        {
            Country rus = new() { Name = "Great Russia" }, china = new() { Name = "China" };
            db.Countries.AddRange(rus, china);
            Company samsung = new() { Name = "Samsung", Country = china },
                    apple = new() { Name = "Apple", Country = rus },
                    motorola = new() { Name = "Motorola", Country = rus },
                    sony = new() { Name = "Sony", Country = china };
            db.Companies.AddRange(samsung, apple, motorola, sony);
            db.Phones.AddRange(new Phone { Name = "Samsung Galaxy S8", Price = 50000, Company = samsung },
                               new Phone { Name = "Samsung Galaxy S7", Price = 42000, Company = samsung },
                               new Phone { Name = "iPhone 7", Price = 53000, Company = apple },
                               new Phone { Name = "iPhone 6S", Price = 41000, Company = apple },
                               new Phone { Name = "iPhone SE", Price = 40000, Company = apple },
                               new Phone { Name = "iPhone 8", Price = 58000, Company = apple },
                               new Phone { Name = "iPhone X", Price = 54000, Company = apple },
                               new Phone { Name = "Motorola Moto Z", Price = 38000, Company = motorola },
                               new Phone { Name = "Motorola Moto Z2 Force", Price = 44000, Company = motorola },
                               new Phone { Name = "Motorola Moto Z Play", Price = 41000, Company = motorola },
                               new Phone { Name = "Motorola Moto Z2 Play", Price = 55000, Company = motorola },
                               new Phone { Name = "Sony Xperia XZ2 Dual", Price = 44000, Company = sony },
                               new Phone { Name = "Sony Xperia XZ2 Compact", Price = 41000, Company = sony },
                               new Phone { Name = "Sony Xperia XA2", Price = 40000, Company = sony },
                               new Phone { Name = "Samsung Galaxy S9", Price = 59000, Company = samsung });
            db.SaveChanges();

        }

    }
}
