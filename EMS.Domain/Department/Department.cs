using Infrastructure.Common.Domain;
using System.Collections.Generic;

namespace EMS.Domain
{
    public class Department : EntityBase<string>
    {
        public Department()
        {
            this.Employees = new HashSet<DepartmentEmployee>();
            this.Managers = new HashSet<DepartmentManager>();
        }

        public string Name { get; set; }

        public virtual ICollection<DepartmentEmployee> Employees { get; set; }

        public virtual ICollection<DepartmentManager> Managers { get; set; }

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