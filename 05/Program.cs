using System;
using System.Linq;
using _01;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context db = new Context();
            SqlParameter param = new ("@price", 50000);
            var phones = db.Phones.FromSqlRaw("SELECT * FROM GetPhonesByPrice (@price)", param).ToList();
            foreach (var p in phones)
                Console.WriteLine($"{p.Name} - {p.Price}");
            Console.ReadKey();
        }
    }
}
