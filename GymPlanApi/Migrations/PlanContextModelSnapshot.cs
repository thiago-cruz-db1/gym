﻿// <auto-generated />
using System;
using GymPlanApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymPlanApi.Migrations
{
    [DbContext(typeof(PlanContext))]
    partial class PlanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GymPlanApi.Model.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("plan_id");

                    b.Property<double>("Amount")
                        .HasColumnType("double")
                        .HasColumnName("plan_price");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("category");

                    b.Property<double>("TotalMonths")
                        .HasColumnType("double")
                        .HasColumnName("plan_duration");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("plans", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
