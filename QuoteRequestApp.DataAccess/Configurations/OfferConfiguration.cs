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
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Mode).IsRequired();
            builder.Property(o => o.MovementType).IsRequired();
            builder.Property(o => o.Incoterms).IsRequired();
            builder.Property(o => o.Country).IsRequired().HasMaxLength(100);
            builder.Property(o => o.City).IsRequired().HasMaxLength(100);
            builder.Property(o => o.PackageType).IsRequired();
            builder.Property(o => o.Unit1).IsRequired();
            builder.Property(o => o.Unit2).IsRequired();
            builder.Property(o => o.Currency).IsRequired();

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Offers)
                   .HasForeignKey(o => o.UserId);
        }
    }
}
