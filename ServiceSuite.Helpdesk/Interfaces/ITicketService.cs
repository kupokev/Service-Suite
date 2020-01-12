using ServiceSuite.Helpdesk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceSuite.Helpdesk.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDto> Get(int id);

        Task<TicketDto[]> GetByAssignee(int assigneeId);
    }
}
