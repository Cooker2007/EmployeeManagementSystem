using EMS.Domain;
using EMS.Services.Interfaces;
using EMS.Services.Messaging.Department;
using EMS.Services.ViewModels;
using System;
using System.Linq;

namespace EMS.Services.Implementations
{
    internal class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public GetDepartmentsResponse GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public GetDepartmentNamesResponse GetDepartmentNames()
        {
            var response = new GetDepartmentNamesResponse();
            var viewModel = new DepartmentNamesViewModel();

            try
            {
                viewModel.Names = this.departmentRepository.GetDepartmentNames();
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                viewModel.Names = Enumerable.Empty<string>();
            }

            response.Departments = viewModel;

            return response;
        }
    }
}