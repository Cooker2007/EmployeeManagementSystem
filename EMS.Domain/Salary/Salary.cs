using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Common;

namespace EMS.Domain
{
    using EmployeeType = Employee;

    public class Salary : EntityBase<int>
    {
        public double Amount { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public virtual EmployeeType Employee { get; set; }

        /// <summary>
        /// Empty constructor for Entity Framework
        /// </summary>
        protected Salary()
        {
        }

        private Salary(int id, double amount, DateTime? fromDate)
        {
            this.Amount = amount;
            this.EmployeeId = id;
            this.FromDate = fromDate;
            this.ToDate = new DateTime(9999, 01, 01);
        }

        protected override void Validate()
        {
            this.ValidateAmount();
            this.ValidateFromDate();
            this.ValidateToDate();
        }

        private void ValidateFromDate()
        {
            if (this.FromDate == null)
            {
                this.AddBrokenRule(SalaryBusinessRule.FromDateMustExist);
            }
        }

        private void ValidateToDate()
        {
            if (!this.ToDate.HasValue)
            {
                this.AddBrokenRule(SalaryBusinessRule.ToDateMustExist);
            }
            else
            {
                if (this.ToDate.IsAfter(this.FromDate))
                {
                    this.AddBrokenRule(SalaryBusinessRule.SalaryToDateIsAfterFromDate);
                }
            }
        }

        private void ValidateAmount()
        {
            if (this.Amount <= 0)
            {
                this.AddBrokenRule(SalaryBusinessRule.SalaryAmountMustBePositive);
            }
        }

        public static Salary CreateSalary(Employee emp, double amount, DateTime? fromDate)
        {
            var salary = new Salary(emp.PersistenceId, amount, fromDate);
            return salary;
        }

        public bool UpdateFromDate(Salary newSalary)
        {
            if(newSalary.FromDate.HasValue && newSalary.FromDate >= this.FromDate)
            {
                this.ToDate = newSalary.FromDate;
                return true;
            }
            return false;
        }
    }
}