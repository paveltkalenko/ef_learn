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
     

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MyConsoleLogger();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
    public class MyConsoleLogger : ILogger
    {
        private object _lock = new object();
        public MyConsoleLogger()
        {
  
        }
        public IDisposable BeginScope<TState>(TState state)
        {

            return null;

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;

        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

            if (formatter != null)
            {
                lock (_lock)
                {
                    Console.WriteLine(formatter(state, exception));
                }
            }

        }
    }
}
