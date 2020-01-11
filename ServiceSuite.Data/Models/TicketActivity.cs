namespace ServiceSuite.Data.Models
{
    public class TicketActivity : BaseEntity
    {
        public int TicketActivityId { get; set; }

        public string Comment { get; set; }

        public bool InternalComment { get; set; }

        public int AssignedUserId { get; set; }

        public int MinutesLogged { get; set; }
    }
}
