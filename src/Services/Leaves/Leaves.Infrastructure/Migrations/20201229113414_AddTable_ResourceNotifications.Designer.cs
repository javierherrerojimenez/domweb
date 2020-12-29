﻿// <auto-generated />
using System;
using Leaves.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leaves.Infrastructure.Migrations
{
    [DbContext(typeof(LeavesContext))]
    [Migration("20201229113414_AddTable_ResourceNotifications")]
    partial class AddTable_ResourceNotifications
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.LeaveAggregate.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<int>("_leaveStatusId")
                        .HasColumnName("LeaveStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("_leaveTypeId")
                        .IsRequired()
                        .HasColumnName("LeaveTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("_resourceId")
                        .IsRequired()
                        .HasColumnName("ResourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_leaveStatusId");

                    b.HasIndex("_leaveTypeId");

                    b.HasIndex("_resourceId");

                    b.ToTable("LEAVES","leaves_db");
                });

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.LeaveAggregate.LeaveStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("LEAVE_STATUS","leaves_db");
                });

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.LeaveTypeAggregate.LeaveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("LEAVE_TYPES","leaves_db");
                });

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.ResourceAggregate.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResourceCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ResourceCode")
                        .IsUnique();

                    b.ToTable("RESOURCES","leaves_db");
                });

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.ResourceAggregate.ResourceNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeaveId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("_lastUpdate")
                        .HasColumnName("LastUpdate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("RESOURCE_NOTIFICATIONS","leaves_db");
                });

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.LeaveAggregate.Leave", b =>
                {
                    b.HasOne("Leaves.Domain.AggregatesModel.LeaveAggregate.LeaveStatus", "LeaveStatus")
                        .WithMany()
                        .HasForeignKey("_leaveStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leaves.Domain.AggregatesModel.LeaveTypeAggregate.LeaveType", null)
                        .WithMany()
                        .HasForeignKey("_leaveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leaves.Domain.AggregatesModel.ResourceAggregate.Resource", null)
                        .WithMany()
                        .HasForeignKey("_resourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Leaves.Domain.AggregatesModel.LeaveAggregate.LeaveReason", "LeaveReason", b1 =>
                        {
                            b1.Property<int>("LeaveId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("LeaveId");

                            b1.ToTable("LEAVES");

                            b1.WithOwner()
                                .HasForeignKey("LeaveId");
                        });
                });

            modelBuilder.Entity("Leaves.Domain.AggregatesModel.ResourceAggregate.ResourceNotification", b =>
                {
                    b.HasOne("Leaves.Domain.AggregatesModel.ResourceAggregate.Resource", null)
                        .WithMany("ResourceNotifications")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
