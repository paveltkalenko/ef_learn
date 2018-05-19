using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore
using DBLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DBLibrary.Contexts
{
    public class ApplicationContext : DbContext
    {
		public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        private readonly ILoggerFactory _loggerFactory;
		public ApplicationContext(ILoggerFactory loggerFactory):base()
		{
            
        
            _loggerFactory = loggerFactory;
            Database.EnsureCreated();

            
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

            
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);

            optionsBuilder.UseSqlServer(conf.GetConnectionString("BloggingDatabase"));

            optionsBuilder.UseLoggerFactory(_loggerFactory);
    
		}

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Order>();
            model.Entity<User>();
        }
       
    }
}
