using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.Services.ViewModels;

namespace EMS.Services.Messaging.Employee
{
    public class ChangeEmployeeSalaryRequest : IntegerIdRequest
    {
        public ChangeEmployeeSalaryRequest(int id) : base(id)
        {
            
        }
        
        public SalaryProperties Properties { get; set; }
    }
}
