using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class SaveTechnicianResource : SaveUserResource
    {
        public string Description { get; set; }
    }
}
