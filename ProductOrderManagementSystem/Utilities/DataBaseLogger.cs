using System;
using ProductOrderManagementSystem.Models;

namespace ProductOrderManagementSystem.Utilities
{
    public class DatabaseLogger : ILogger
    {
        private readonly ProductOrderContext _context;

        public DatabaseLogger(ProductOrderContext context)
        {
            _context = context;
        }

        public void Log(string message)
        {
            _context.Logs.Add(new Log { Message = message, Timestamp = DateTime.Now });
            _context.SaveChanges();
        }
    }
}
