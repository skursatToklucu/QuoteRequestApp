using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using QuoteRequestApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteRequestApp.DataAccess.Configurations
{
    public class DimensionConfiguration : IEntityTypeConfiguration<Dimension>
    {
        public void Configure(EntityTypeBuilder<Dimension> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Type).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Width).IsRequired();
            builder.Property(d => d.Length).IsRequired();
            builder.Property(d => d.Height).IsRequired();

            builder.HasData(
                new Dimension { Type = "Carton", Width = 12, Length = 12, Height = 12 },
                new Dimension { Type = "Box", Width = 24, Length = 16, Height = 12 },
                new Dimension { Type = "Pallet", Width = 40, Length = 48, Height = 60 }
            );
        }
    }
}
