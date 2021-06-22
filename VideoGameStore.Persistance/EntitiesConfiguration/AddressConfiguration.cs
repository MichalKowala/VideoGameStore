using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Persistance.EntitiesConfiguration
{
    public class AddressConfiguration : BaseEntityConfiguration<Address>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(x => x.Developer).WithOne(x => x.HeadquartersLocation).HasForeignKey<Developer>(x => x.HeadquartersLocationId);
            builder.HasOne(x => x.Publisher).WithOne(x => x.HeadquartersLocation).HasForeignKey<Publisher>(x => x.HeadquartersLocationId);
        }
    }
}
