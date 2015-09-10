using System;

namespace EMS.Services.Implementations
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(string message)
            : base(message)
        {
        }

        private ResourceNotFoundException()
            : base("The requested resource was not found.")
        {
        }
    }
}