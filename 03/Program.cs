using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _01;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                //вставка
                string htc = "htc";
                int numberOfRowInserted = db.Database.ExecuteSqlRaw("INSERT INTO Companies (Name) VALUES ({0})", htc);
                Console.WriteLine($"numberOfRowInserted = {numberOfRowInserted}");
                ShowCompanies(db);
                // обновление
                string nokia = "Nokia";
                int id = 3;
                int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Companies SET Name={0} WHERE Id={1}", nokia, numberOfRowInserted);
                Console.WriteLine($"numberOfRowUpdated = {numberOfRowUpdated}");
                ShowCompanies(db);
                // удаление
                int numberOfRowDeleted = db.Database.ExecuteSqlRaw("DELETE FROM Companies WHERE Id={0}", numberOfRowUpdated);
                Console.WriteLine($"numberOfRowDeleted = {numberOfRowDeleted}");

                ShowCompanies(db);
                Console.ReadKey();
            }
        }
        static void ShowCompanies(Context db)
        {
            foreach (var c in db.Companies.FromSqlRaw("select * from Companies"))
                Console.WriteLine($"{c.Name} Id: {c.Id}");
        }
    }
}
