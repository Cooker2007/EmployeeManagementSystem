using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Common;

namespace EMS.Domain
{
    public class Employee : EntityBase<int>
    {
        protected Employee()
        {
        }

        private Gender gender;

        private Employee(string firstName, string lastName, DateTime? birthDate, DateTime? hireDate, Gender gender)
        {
            this.Gender = gender;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.HireDate = hireDate;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string GenderDatabase { get; set; }

        public Gender Gender
        {
            get
            {
                Gender.TryParse(this.GenderDatabase, out this.gender);
                return this.gender;
            }
            set
            {
                this.gender = value;
                this.GenderDatabase = value.DisplayName[0].ToString();
            }
        }

        public DateTime? BirthDate { get; private set; }

        public DateTime? HireDate { get; private set; }

        public virtual ICollection<DepartmentEmployee> Departments { get; set; } = new HashSet<DepartmentEmployee>();

        public virtual ICollection<DepartmentManager> Managers { get; set; } = new HashSet<DepartmentManager>();

        public virtual ICollection<Salary> Salaries { get; set; } = new HashSet<Salary>();

        public virtual ICollection<Title> Titles { get; set; } = new HashSet<Title>();

        protected override void Validate()
        {
            this.ValidateRequiredFieldsHaveValues();
            this.ValidateBirthDate();
            this.ValidateHireDate();
        }

        private void ValidateBirthDate()
        {
            if (this.BirthDate.IsBefore(DateTime.Today))
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeBirthDateNotInFuture);
            }
        }

        private void ValidateHireDate()
        {
            if (this.BirthDate.IsBefore(this.HireDate))
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeHiredAfterBorn);
            }
        }

        private void ValidateRequiredFieldsHaveValues()
        {
            if (string.IsNullOrWhiteSpace(this.FirstName))
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeFirstNameRequired);
            }
            if (string.IsNullOrWhiteSpace(this.LastName))
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeLastNameRequired);
            }
            if (this.Gender == null || Equals(this.Gender, Gender.Unknown))
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeGenderRequired);
            }
            if (this.BirthDate == null)
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeBirthDateRequired);
            }
            if (this.HireDate == null)
            {
                this.AddBrokenRule(EmployeeBusinessRule.EmployeeHireDateRequired);
            }
        }

        private void SetGender(string value)
        {
            Gender temp;
            if (Gender.TryParse(value, out temp))
            {
                this.Gender = temp;
            }
            else
            {
                this.Gender = Domain.Gender.Other;
            }
        }

        private void UpdateEmployeeData(string firstName = null, string lastName = null, string birthDate = null,
            string updateGender = null)
        {
            if (updateGender != null)
            {
                Gender result;
                if (Domain.Gender.TryParse(updateGender, out result))
                {
                    this.UpdateEmployeeData(firstName, lastName, birthDate, result);
                }
            }

            this.UpdateEmployeeData(firstName, lastName, birthDate, (Gender)null);
        }

        public void UpdateEmployeeData(string firstName = null, string lastName = null, string birthDate = null, Gender updateGender = null)
        {
            if (firstName != null)
            {
                this.FirstName = firstName;
            }
            if (lastName != null)
            {
                this.LastName = lastName;
            }
            if (birthDate != null)
            {
                DateTime result;
                if (DateTime.TryParse(birthDate, out result))
                {
                    this.BirthDate = result.Date;
                }
            }
            if (updateGender != null)
            {
                this.Gender = updateGender;
            }
        }

        public static Employee CreateEmployee(string firstName, string lastName, DateTime? birthDate, DateTime? hireDate, Gender gender)
        {
            var newEmployee = new Employee(firstName, lastName, birthDate, hireDate, gender);
            return newEmployee;
        }

        public void AddSalary(Salary salary)
        {
            this.Salaries.Add(salary);
        }


        public bool AddDepartmentEmployee(DepartmentEmployee departmentEmployee)
        {
            if (departmentEmployee.FromDate.HasValue)
            {
                this.UpdatePreviousDepartment(departmentEmployee.FromDate.Value);
                this.Departments.Add(departmentEmployee);
                return true;
            }
            return false;
        }

        private void UpdatePreviousDepartment(DateTime toDate)
        {
            if (this.Departments.Count > 0)
            {
                var previousDept = this.Departments.OrderByDescending(d => d.FromDate).FirstOrDefault();

                if (previousDept != null)
                {
                    previousDept.ToDate = toDate;
                }
            }
        }

        public bool AddTitle(Title title)
        {
            if (title.FromDate.HasValue)
            {
                this.UpdatePreviousTitle(title.FromDate.Value);
                this.Titles.Add(title);
                return true;
            }
            return false;
        }

        private void UpdatePreviousTitle(DateTime toDate)
        {
            if (this.Titles.Count > 0)
            {
                var previousTitle = this.Titles.OrderByDescending(t => t.FromDate).FirstOrDefault();
                if (previousTitle != null)
                {
                    previousTitle.ToDate = toDate;
                }

            }
        }
    }
}