using System;

namespace ServiceSuite.Data.Models
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public int CreatedById { get; set; }
    }
}
