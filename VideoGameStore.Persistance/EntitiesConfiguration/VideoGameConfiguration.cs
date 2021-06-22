using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Entities;

namespace VideoGameStore.Persistance.EntitiesConfiguration
{
    public class VideoGameConfiguration : BaseEntityConfiguration<VideoGame>
    {
        public override void ConfigureEntity(EntityTypeBuilder<VideoGame> builder)
        {
            builder.HasOne(x => x.Publisher).WithMany(x => x.Games).HasForeignKey(x => x.PublisherId);
            builder.HasOne(x => x.Developer).WithMany(x => x.Games).HasForeignKey(x => x.DeveloperId);

        }
    }
}
