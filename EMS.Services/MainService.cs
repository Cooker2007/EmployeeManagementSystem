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
        static private EMSContext Context { get;}

        private static IEmployeeRepository EmployeeRepository { get;}
        private static IDepartmentRepository DepartmentRepository { get;}
        private static ISalaryRepository SalaryRepository { get;}
        private static ITitleRepository TitleRepositoy { get;}
        private static IDepartmentEmployeeRepository DepartmentEmployeeRepository { get;}

        public static IEmployeeService EmployeeService { get;}
        public static IDepartmentService DepartmentService { get;}
        public static ISalaryService SalaryService { get;}

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