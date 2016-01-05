using Infrastructure.Common.Domain;
using System;
using System.Security.Cryptography;

namespace EMS.Domain
{
    using EmployeeType = Employee;

    public class DepartmentEmployee : EntityBase<int>
    {
        protected DepartmentEmployee()
        {
            
        }

        private DepartmentEmployee(string departmentId, int employeeId, DateTime? fromDate)
        {
            this.DepartmentId = departmentId;
            this.EmployeeId = employeeId;
            this.FromDate = fromDate;
            this.ToDate = new DateTime(9999,01,01);
        }

        public string DepartmentId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public virtual Department Department { get; set; }

        public virtual EmployeeType Employee { get; set; }

        protected override void Validate()
        {
            this.ValidateDates();
        }

        private void ValidateDates()
        {
            if (!this.ToDate.HasValue || !this.FromDate.HasValue)
            {
                return;
            }
            int compareValue = DateTime.Compare(this.ToDate.GetValueOrDefault(), this.FromDate.Value);

            if (compareValue < 0)
            {
                this.AddBrokenRule(DepartmentEmployeeBusinessRule.DepartmentEmployeeToDateIsAfterFromDate);
            }
        }

        public static DepartmentEmployee CreateDepartmentEmployee(string departmentId, int employeeId, DateTime fromDate)
        {
            DepartmentEmployee de = new DepartmentEmployee(departmentId, employeeId,fromDate);
            return de;
        }

    }
}