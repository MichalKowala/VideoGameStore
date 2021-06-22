using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Persistance.EntitiesConfiguration
{
    public class DeveloperConfiguration : BaseEntityConfiguration<Developer>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Developer> builder)
        {
            builder.HasOne(x => x.HeadquartersLocation).WithOne(x => x.Developer).HasForeignKey<Address>(x => x.DeveloperId);
            builder.HasMany(x => x.Games).WithOne(x => x.Developer);
        }
    }
}
