using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Resources
{
    public class SaveDistrictResource
    {
        [Required]
        public string Name { get; set; }
    }
}
