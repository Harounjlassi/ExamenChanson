using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastructure.Configurations
{
    public class ConcertsConfiguration : IEntityTypeConfiguration<Concert>

    {
       

        public void Configure(EntityTypeBuilder<Concert> builder)
        {
          /**
            builder.HasOne(artistc => artistc.Artiste)
               .WithMany(concerets => concerets.concerts)
               .HasForeignKey(c => c.ArtisteFk);
            builder.HasOne(fs => fs.Festival)
            .WithMany(concerets => concerets.concerts)
            .HasForeignKey(c => c.FestivalFk);

            builder.HasKey(c => new {c.DateConcert,c.FestivalFk,c.ArtisteFk});
          */

        }
    }
}
