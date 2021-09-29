using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class ReportResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TechnicianResource Technician { get; set; }
        public CustomerResource Customer { get; set; }
    }
}
