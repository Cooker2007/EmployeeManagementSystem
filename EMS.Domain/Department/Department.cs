using Infrastructure.Common.Domain;
using System.Collections.Generic;

namespace EMS.Domain
{
    public class Department : EntityBase<string>
    {
        protected Department()
        {
        }

        public string Name { get; set; }

        public virtual ICollection<DepartmentEmployee> Employees { get; set; } = new HashSet<DepartmentEmployee>();

        public virtual ICollection<DepartmentManager> Managers { get; set; } = new HashSet<DepartmentManager>();

        protected override void Validate()
        {
            this.ValidateName();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.AddBrokenRule(DepartmentBusinessRule.DepartmentNameRequired);
            }
        }
    }
}