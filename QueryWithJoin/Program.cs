using System;
using DBLibrary.Contexts;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
namespace QueryWithJoin
{
    class Program
    {
        static void RawSqlQuery(ApplicationContext contexts )
        {
            using (var connection = contexts.Database.GetDbConnection())
            {
                Debug.WriteLine($"Get Connection status is {connection.State}");
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                    Debug.WriteLine($"Connection status - {connection.State}");
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT U.Name,o.description FROM Users U JOIN Orders o on o.UserId=U.ID";
                    var result = command.ExecuteReader();
                    if (result.HasRows)
                    {
                        Console.WriteLine("{0}\t{1}", result.GetName(0), result.GetName(1));
                        while (result.Read())
                        {
                            object Name = result.GetValue(0);
                            object desc = result.GetValue(1);
                            Console.WriteLine($"{Name}\t{desc}");
                        }
                    }
                }


                }
                Debug.WriteLine("Everething is fine");
        }
        static void Main(string[] args)
        {
            using (var db = new ApplicationContext(null))
            {
                RawSqlQuery(db);

            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
