using EMS.Domain;
using Infrastructure.Common;
using System.Collections.Generic;
using System.Linq;

namespace EMS.Data.Repositories
{
    public class TitleRepository : RepositoryBase<Title, int, EMSContext>, ITitleRepository
    {
        public TitleRepository(EMSContext context)
            : base(context)
        {
        }

        public IEnumerable<Title> GetTitleHistory(int employeeId)
        {
            IEnumerable<Title> titleHistory =
                this.Context.Titles.Where(e => e.EmployeeId == employeeId).OrderByDescending(e => e.FromDate);

            return titleHistory;
        }

        public Title GetEmployeeCurrentTitle(int employeeId)
        {
            var title =
                this.Context.Titles.Where(e => e.EmployeeId == employeeId)
                    .OrderByDescending(e => e.FromDate)
                    .FirstOrDefault();

            return title;
        }
    }
}