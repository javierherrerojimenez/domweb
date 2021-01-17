using Duties.Domain.AggregatesModel.DutyAggregate;
using Duties.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Duties.Infrastructure.EntityConfigurations
{
    class DutyEntityTypeConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.ToTable("DUTIES", DutiesContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property<string>("Name").IsRequired();
            builder.Property<DateTime>("DateStart").IsRequired();
            builder.Property<DateTime>("DateEnd").IsRequired();
            builder.Property<int>("HourStart").IsRequired();
            builder.Property<int>("HourEnd").IsRequired();
            builder.Property<string>("NodeStart");
            builder.Property<string>("NodeEnd");

            builder.Property<bool>("_isNew")
             .UsePropertyAccessMode(PropertyAccessMode.Field)
             .HasColumnName("IsNew")
             .HasDefaultValue(false)
             .IsRequired();

            builder.Property<DateTime>("_createdTime")
             .UsePropertyAccessMode(PropertyAccessMode.Field)
             .HasColumnName("CreatedTime")
             .HasDefaultValue(DateTime.UtcNow)
             .IsRequired();

            //builder.HasIndex(p => new { p.Name }).IsUnique();
        }
    }
}
