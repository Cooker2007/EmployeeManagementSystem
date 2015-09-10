using Infrastructure.Common.Domain;
using System;

namespace EMS.Domain
{
    public partial class DepartmentManager : EntityBase<int>
    {
        public string DepartmentId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public virtual Department Department { get; set; }

        public virtual Employee Employee { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}