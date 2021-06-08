using System;
using System.Data;
using System.Linq;
using _01;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context db = new ();
            Console.WriteLine("--- Stored Procedures ---");

            SqlParameter param1 = new ("@name", "Samsung");
            var phones = db.Phones.FromSqlRaw("GetPhonesByCompany @name", param1).ToList();
            foreach (var p in phones) Console.WriteLine($"{p.Name} - {p.Price}");
            Console.WriteLine("--- OUTPUT ---");

            var param2 = new SqlParameter
            {
                ParameterName = "@phoneName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Output,
                Size = 50
            };
            db.Database.ExecuteSqlRaw("GetPhoneWithMaxPrice @phoneName OUT", param2);
            Console.WriteLine(param2.Value);
            Console.ReadKey();
        }
    }
}
