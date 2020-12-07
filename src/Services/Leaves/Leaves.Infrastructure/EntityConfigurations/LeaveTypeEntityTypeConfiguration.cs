using Leaves.Domain.AggregatesModel.LeaveAggregate;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaves.Infrastructure.EntityConfigurations
{
    class LeaveTypeEntityTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> leaveTypeConfiguration)
        {
            leaveTypeConfiguration.ToTable("LEAVE_TYPES", LeavesContext.DEFAULT_SCHEMA);

            leaveTypeConfiguration.HasKey(o => o.Id);

            // leaveTypeConfiguration.Ignore(b => b.DomainEvents);
            // jherrerOJO: Igual se pone el Ignore en DomainEvents quizá habría que ignorar todos los demás o no definirlos directamente en esta clase porque al crear la clase la primera vez se duplicaron campos
            // La solución fue editar las primeras migraciones donde se creaban duplicados esos campos en las tablas 
           /* leaveTypeConfiguration
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired();

            leaveTypeConfiguration
                .Property<string>("_code")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Code")
                .IsRequired();

            leaveTypeConfiguration
                .Property<bool>("_isPaid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsPaid")
                .IsRequired();*/
        }

    }
}
