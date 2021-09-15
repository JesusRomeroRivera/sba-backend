using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //One to Many Reverse Relationship
        public IList<User> Users { get; set; } = new List<User>();
    }
}
