using EMS.Services.Implementations;
using EMS.Services.Interfaces;
using System;

namespace EMS.Services
{
    using EMS.Data;
    using EMS.Data.Repositories;
    using EMS.Domain;

    /// <summary>
    /// Instantiates the EntityFramework Context and the repositories
    /// </summary>
    static public class MainService
    {
        static private EMSContext Context { get; set; }

        private static IEmployeeRepository EmployeeRepository { get; set; }
        private static IDepartmentRepository DepartmentRepository { get; set; }
        private static ISalaryRepository SalaryRepository { get; set; }
        private static ITitleRepository TitleRepositoy { get; set; }
        private static IDepartmentEmployeeRepository DepartmentEmployeeRepository { get; set; }

        public static IEmployeeService EmployeeService { get; private set; }
        public static IDepartmentService DepartmentService { get; private set; }
        public static ISalaryService SalaryService { get; private set; }

        static MainService()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.Environment.CurrentDirectory);
            Context = new EMSContext();

            EmployeeRepository = new EmployeeRepository(Context);
            DepartmentRepository = new DepartmentRepository(Context);
            SalaryRepository = new SalaryRepository(Context);
            TitleRepositoy = new TitleRepository(Context);
            DepartmentEmployeeRepository = new DepartmentEmployeeRepository(Context);

            EmployeeService = new EmployeeService(DepartmentEmployeeRepository, DepartmentRepository, EmployeeRepository, SalaryRepository, TitleRepositoy);
            DepartmentService = new DepartmentService(DepartmentRepository);
            SalaryService = new SalaryService(SalaryRepository);
        }
    }
}