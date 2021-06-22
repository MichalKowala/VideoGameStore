using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Entities
{
    public class Publisher : EntityBase
    {
        public string CompanyName { get; set; }
        public Address? HeadquartersLocation { get; set; }
        public Guid? HeadquartersLocationId { get; set; }
        public List<VideoGame>? Games { get; set; } 
    }
}
