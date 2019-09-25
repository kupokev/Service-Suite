using System.ComponentModel.DataAnnotations;

namespace ServicePortal.Data.Models.Entity
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
    }
}
