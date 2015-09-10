using EMS.Services.Messaging.Employee;

namespace EMS.Services.Interfaces
{
    public interface IEmployeeService
    {
        #region CRUD

        GetEmployeesResponse GetAllEmployees();

        GetEmployeeResponse GetEmployee(GetEmployeeRequest getEmployeeRequest);

        InsertEmployeeResponse InsertEmployee(InsertEmployeeRequest insertEmployeeRequest);

        UpdateEmployeeResponse UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);

        UpdateEmployeeResponse DeleteEmployee(DeleteEmployeeRequest deleteEmployeeRequest);

        #endregion CRUD

        #region Employee's Historical Data

        GetEmployeeDepartmentHistoryResponse GetDepartmentHistory(
            GetEmployeeDepartmentHistoryRequest getEmployeeDepartmentHistoryRequest);

        GetEmployeeTitleHistoryResponse GetTitleHistory(
            GetEmployeeTitleHistoryRequest getEmployeeTitleHistoryRequest);

        GetEmployeeSalaryHistoryResponse GetSalaryHistory(GetEmployeeSalaryHistoryRequest request);

        #endregion Employee's Historical Data

        GetEmployeeSalaryResponse GetCurrentSalary(GetEmployeeSalaryRequest request);

        ChangeEmployeeDepartmentResponse ChangeDepartment(ChangeEmployeeDepartmentRequest request);

        ChangeEmployeeSalaryResponse ChangeSalary(ChangeEmployeeSalaryRequest request);

        ChangeEmployeeTitleResponse ChangeTitle(ChangeEmployeeTitleRequest request);
    }
}