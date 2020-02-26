using System;


namespace WebApplication7.Services.Exceptions
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException (string message) : base(message)
        {
        }
    }
}
