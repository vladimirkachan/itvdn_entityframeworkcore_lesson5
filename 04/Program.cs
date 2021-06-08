using System;
using System.Linq;
using _01;
using Microsoft.EntityFrameworkCore;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Context();
            Console.WriteLine("--- String Interpolation ---");

            var name = "%Galaxy%";
            var price = 30000;
            var phones = db.Phones.FromSqlInterpolated($"SELECT * FROM Phones WHERE Name LIKE {name} AND Price > {price}").ToList();
            foreach (var phone in phones)
                Console.WriteLine($"{phone.Name} - {phone.Price:C}\n");

            Console.ReadKey();
        }
    }
}
