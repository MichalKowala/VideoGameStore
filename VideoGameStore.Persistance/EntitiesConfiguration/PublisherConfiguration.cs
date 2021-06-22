using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Persistance.EntitiesConfiguration
{
    public class PublisherConfiguration : BaseEntityConfiguration<Publisher>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasMany(x => x.Games).WithOne(x => x.Publisher);
            builder.HasOne(x => x.HeadquartersLocation).WithOne(x => x.Publisher).HasForeignKey<Address>(x => x.PublisherId);
        }
    }
}
