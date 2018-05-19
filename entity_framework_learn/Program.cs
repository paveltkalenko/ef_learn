using System;
using System.Linq;
using System.Collections.Generic;
using DBLibrary.Contexts;
using DBLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Console;
using Microsoft.EntityFrameworkCore;
namespace entity_framework_learn
{//https://weblogs.asp.net/dixin/entity-framework-core-and-linq-to-entities-3-logging-and-tracing-queries
    class Program
    {
		static void Main(string[] args)
        {
            ILoggerFactory lf = new LoggerFactory();
          

               lf.AddProvider(new MyLoggerProvider());

            using (ApplicationContext db = new ApplicationContext(lf))
			{
                 //  	User u1 = new User() { Name = "Tolik", Age = 31 };
                //     User u2 = new User() { Name = "Alkogolik", Age = 28 };
                //   Order o1 = new Order() { UserId = 9, description = "Tolik-1 buy shoes" };
               //    db.Users.Add(u1);
                //     db.Users.Add(u2);
                //      db.Orders.Add(o1);
                //        db.SaveChanges();
          
               
                    
                    var query = (from u in db.Users
                                 join o in db.Orders on u.Id equals o.UserId
                                 select new { Name = u.Name, Description = o.description }).ToList();
                    
                    foreach (var u in query)
                    {
                        Console.WriteLine($"{u.Name}\t{u.Description}");
                    }

                
               
			}

			
			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
		
    }
}
