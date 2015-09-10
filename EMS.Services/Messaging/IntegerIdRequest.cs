using System;

namespace EMS.Services.Messaging
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {
        protected IntegerIdRequest(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be positive.", "id");
            }
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}