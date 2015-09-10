using EMS.Services.ViewModels;
using System.Collections.Generic;

namespace EMS.Services.Messaging.Employee
{
    public class GetEmployeeTitleHistoryResponse : ServiceResponseBase
    {
        public IEnumerable<TitleViewModel> TitleHistory { get; set; }
    }
}