using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class OpinionResource
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public TechnicalResource Technical { get; set; }
        public CustomerResource Customer { get; set; }
    }
}
