using EMS.Domain;
using EMS.Services.Interfaces;
using EMS.Services.Messaging.Salary;
using System;

namespace EMS.Services.Implementations
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            this.salaryRepository = salaryRepository;
        }

        public InsertSalaryResponse InsertSalary(InsertSalaryRequest request)
        {
            throw new NotImplementedException();
        }

        private ResourceNotFoundException GetStandardSalaryNotFoundException()
        {
            throw new ResourceNotFoundException("The requested salary was not found.");
        }
    }
}