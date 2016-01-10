using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Data;
using EMS.Data.Repositories;
using EMS.Domain;
using EMS.Services.Interfaces;
using SimpleInjector;
using EMS.Services;

namespace EMS.DesktopInterface
{
    class IoCContainer
    {
        public static Container CreateContainer()
        {
            var container = new Container();
            
            container.Register<IDepartmentRepository, DepartmentRepository>();
            container.Register<IDepartmentEmployeeRepository, DepartmentEmployeeRepository>();
            container.Register<IEmployeeRepository, EmployeeRepository>();
            container.Register<ISalaryRepository, SalaryRepository>();
            container.Register<ITitleRepository, TitleRepository>();

            container.Register<IDepartmentService, DepartmentService>();
            container.Register<IEmployeeService, EmployeeService>();
            container.Register<ISalaryService, SalaryService>();

            container.Register<MainWindow>();
            container.Register<ChangeDepartment>();
            container.Register<ChangeSalary>();
            container.Register<ChangeTitle>();
            container.Register<CreateEmployee>();
            container.Register<Processing>();

            container.Register<EMSContext, EMSContext>(Lifestyle.Singleton);

            container.Verify();

            return container;
        }

    }
}
