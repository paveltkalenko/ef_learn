using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore
using entity_framework_learn.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace entity_framework_learn.Contexts
{
    public class ApplicationContext : DbContext
    {
		public DbSet<User> Users { get; set; }
        private readonly ILoggerFactory _loggerFactory;
		public ApplicationContext(ILoggerFactory loggerFactory)
		{
			Database.EnsureCreated();
            Console.WriteLine("WE HAVE loggerFactory");
            _loggerFactory = loggerFactory;
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            //optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = helloappdb; Trusted_Connection = True; ");
            //	var connectionString = ConfigurationManager.ConnectionStrings["dataConnection"].ConnectionString;
            //
			IConfigurationRoot conf = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

            Console.WriteLine("UseLoggerFactory");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
          //  optionsBuilder.UseLoggerFactory(_loggerFactory);

            Console.WriteLine("AfterUseLoggerFactorr");
          
            optionsBuilder.UseSqlServer(conf.GetConnectionString("BloggingDatabase"));
        //    optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.UseLoggerFactory(new LoggerFactory().AddConsole());//почему-то только так работает???

		}
       
    }
}
