using System;
using System.Collections.Generic;
using System.Text;

namespace DBLibrary.Models
{
    public class User
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Age { get; set; }

    }
    public class 
        Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string description { get; set; }
    }
    
    public class OrderUserVisual
    {
        public string Name { get; set; }
        public string description { get; set; }
    }
    
}
