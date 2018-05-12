using System;
using System.Linq;
using System.Collections.Generic;
using entity_framework_learn.Contexts;
using entity_framework_learn.Models;
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
            //ILoggerFactory lf = new LoggerProvider();
          
            var lf = new LoggerFactory().AddConsole();
        //    var clf = lf.AddConsole();
          //  lf.
        //    lf.AddDebug();
         //   lf.AddProvider(new MyLoggerProvider());
         
           // lf.AddConsole(LogLevel.Trace);
         //   var log = lf.CreateLogger("MyConsoleLogger");
          //  log.LogInformation("HELLO");
            Console.WriteLine("Before Context Create");
            using (ApplicationContext db = new ApplicationContext(lf))
			{
                //   db.Database.
                	User u1 = new User() { Name = "Tolik", Age = 31 };
                    User u2 = new User() { Name = "Alkogolik", Age = 28 };

                    db.Users.Add(u1);
                    db.Users.Add(u2);

                    db.SaveChanges();
                    
                 var us = db.Users.ToList<User>();
                foreach (User u in us)
                    {
                          Console.WriteLine(u.Name);
                    }
                 
               
			}

			
			Console.WriteLine("Hello World!");
			Console.ReadKey();
		}
		
    }
}
