using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace entity_framework_learn
{
    public class MyLoggerProvider : ILoggerProvider
    {
        public MyLoggerProvider()
        {
            Console.WriteLine("Konstructor");

        }

        public ILogger CreateLogger(string categoryName)
        {
            Console.WriteLine($"CREATE LOGGER categoryName = {categoryName}");
            return new MyConsoleLogger();
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
    public class MyConsoleLogger : ILogger
    {
       // private object _lock = new object();
        public MyConsoleLogger()
        {
            Console.WriteLine("MyConsoleLogger - constructor");
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            Console.WriteLine("BeginScope");
            return null;
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            Console.WriteLine("IsEnabled");
            return true;
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine("logger");
            
          //  if (formatter != null)
          //  {
            //    lock (_lock)
             //   {
                    Console.WriteLine(formatter(state, exception));
              //  }
        //    }
           // throw new NotImplementedException();
        }
    }
}
