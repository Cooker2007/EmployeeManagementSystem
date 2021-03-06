using System;
using Infrastructure.Common;

namespace EMS.Domain
{
    using EmployeeType = Employee;

    public class Title : EntityBase<int>
    {
        /// <summary>
        /// Do not use. Needed for Entity Framework
        /// </summary>
        protected Title() { }

        private Title(int employeeId, string name, DateTime? fromDate)
        {
            this.Name = name;
            this.EmployeeId = employeeId;
            this.FromDate = fromDate;
            this.ToDate = new DateTime(9999, 01, 01);
        }

        public string Name { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public virtual EmployeeType Employee { get; set; }

        protected override void Validate()
        {
            this.ValidateName();
            this.ValidateDates();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
            {
                this.AddBrokenRule(TitleBusinessRule.TitleNameRequired);
            }
        }

        private void ValidateDates()
        {
            if (!this.ToDate.HasValue || !this.FromDate.HasValue)
            {
                return;
            }
            if (this.ToDate.IsAfter(this.FromDate))
            {
                this.AddBrokenRule(DepartmentEmployeeBusinessRule.DepartmentEmployeeToDateIsAfterFromDate);
            }
        }

        public static Title CreateTitle(int empId, string titleName, DateTime fromDate)
        {
            var newTitle = new Title(empId, titleName, fromDate);
            return newTitle;
        }


    }
}