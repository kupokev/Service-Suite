using Microsoft.EntityFrameworkCore;
using ServiceSuite.Data.Contexts;
using ServiceSuite.Helpdesk.Interfaces;
using ServiceSuite.Helpdesk.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceSuite.Helpdesk.Services
{
    public class TicketService : ITicketService
    {
        private readonly MainContext _context;

        public TicketService(MainContext context)
        {
            _context = context;
        }

        public async Task<TicketDto> Get(int id)
        {
            return await _context.Tickets.Where(x => x.TicketId == id)
                .Select(x => new TicketDto()
                {
                    AssigneeId = x.AssignedUserId ?? 0,
                    Assignee = x.AssignedUserId.ToString(),
                    CreatedBy = x.CreatedById.ToString(),
                    CreatedById = x.CreatedById,
                    CreatedOn = x.CreatedDate,
                    Description = x.Description,
                    Name = x.Name,
                    Priority = x.Priority.ToString(),
                    PriorityId = x.Priority,
                    Status = x.StatusId.ToString(),
                    StatusId = x.StatusId,
                    TicketId = x.TicketId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TicketDto[]> GetByAssignee(int assigneeId)
        {
            return (await _context.Tickets.Where(x => x.AssignedUserId == assigneeId)
                .Select(x => new TicketDto()
                {
                    AssigneeId = x.AssignedUserId ?? 0,
                    Assignee = x.AssignedUserId.ToString(),
                    CreatedBy = x.CreatedById.ToString(),
                    CreatedById = x.CreatedById,
                    CreatedOn = x.CreatedDate,
                    Description = x.Description,
                    Name = x.Name,
                    Priority = x.Priority.ToString(),
                    PriorityId = x.Priority,
                    Status = x.StatusId.ToString(),
                    StatusId = x.StatusId,
                    TicketId = x.TicketId
                })
                .ToListAsync()
                ).ToArray();
        }
    }
}
