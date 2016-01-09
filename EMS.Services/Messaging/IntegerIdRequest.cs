using System;

namespace EMS.Services.Messaging
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {
        /// <exception cref="ArgumentException">ID must be positive.</exception>
        protected IntegerIdRequest(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be positive.", nameof(id));
            }
            this.Id = id;
        }

        public int Id { get;}
    }
}