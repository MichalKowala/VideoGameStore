using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Enums;

namespace VideoGameStore.Domain.Entities
{
    public class VideoGame : EntityBase
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }

        public PegiAgeRestriction PegiAgeRestriction { get; set; }
        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }
       
    }
}
