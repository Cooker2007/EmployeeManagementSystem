using System;
using System.Collections.Generic;
using Infrastructure.Common.Domain;

namespace Infrastructure.Common
{
    public abstract class EntityBase<TIdType> : IEntity<TIdType>
    {
        public TIdType DatabaseId { get; set; }

        public Guid Guid { get; set; }

        private List<BusinessRule> brokenRules = new List<BusinessRule>();

        public override bool Equals(object obj)
        {
            return obj is EntityBase<TIdType> && this == (EntityBase<TIdType>)obj;
        }

        public override int GetHashCode()
        {
            return this.Guid.GetHashCode();
        }

        public static bool operator ==(EntityBase<TIdType> entity1, EntityBase<TIdType> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }
            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }
            if (entity1.Guid == entity2.Guid)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(EntityBase<TIdType> entity1, EntityBase<TIdType> entity2)
        {
            return (!(entity1 == entity2));
        }

        protected abstract void Validate();

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            this.brokenRules.Add(businessRule);
        }

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            this.brokenRules.Clear();
            this.Validate();
            return this.brokenRules;
        }
    }
}