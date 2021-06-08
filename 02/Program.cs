using System;
using System.Linq;
using _01;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context db = new ();
            Console.WriteLine("--- SqlParameter: #1 ---");

            SqlParameter param = new ("@name", "%Sony%");
            var phones1 = db.Phones.FromSqlRaw("SELECT * FROM Phones WHERE Name LIKE @name", param).ToList();
            foreach (var phone in phones1) Console.WriteLine(phone.Name);
            Console.WriteLine("--- SqlParameter: #2 ---");

            var name = "%Galaxy%";
            var phones2 = db.Phones.FromSqlRaw("SELECT * FROM Phones WHERE Name LIKE {0}", name).ToList();
            foreach (var phone in phones2) Console.WriteLine(phone.Name);
            Console.WriteLine("--- SqlParameter: #3 ---");

            var price = 30000;
            var phones3 = db.Phones.FromSqlRaw("SELECT * FROM Phones WHERE Price > {0}", price).ToList();
            foreach (var phone in phones3) Console.WriteLine(phone.Name);
            Console.WriteLine("--- Finish ---");
            Console.ReadKey();
        }
    }
}
