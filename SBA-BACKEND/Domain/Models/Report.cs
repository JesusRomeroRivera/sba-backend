using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }

        //One to Many Relationship
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //One to Many Relationship
        public int TechnicalId { get; set; }
        public Technical Technical { get; set; }
    }
}
