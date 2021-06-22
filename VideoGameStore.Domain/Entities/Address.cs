using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Domain.Entities
{
    public class Address : EntityBase
    {
        
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Guid? DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        
    }
}
