using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressInfo.City.Entities.Concrete.EFMappings
{
    public class CityMap : IEntityTypeConfiguration<City>

    {

        public void Configure(EntityTypeBuilder<City> builder)

        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CityName)

                   .IsRequired()

                   .HasMaxLength(50);

            builder.Property(e => e.CityCode)

                   .IsRequired();

            builder.Property(e => e.DistrictName)

                   .IsRequired()

                   .HasMaxLength(50);

            builder.Property(e => e.ZipCode)

                   .IsRequired();

        }

    }
}
