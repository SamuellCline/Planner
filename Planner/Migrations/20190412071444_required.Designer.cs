﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Planner.Models;

namespace Planner.Migrations
{
    [DbContext(typeof(PlannerContext))]
    [Migration("20190412071444_required")]
    partial class required
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Planner.Models.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClosingPrayer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ClosingSong");

                    b.Property<string>("Conducting");

                    b.Property<DateTime>("Date");

                    b.Property<string>("OpeningPrayer")
                        .IsRequired();

                    b.Property<int>("OpeningSong");

                    b.Property<int>("SacramentHymn");

                    b.Property<string>("Speaker1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Speaker2")
                        .HasMaxLength(50);

                    b.Property<string>("TalkTopic1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TalkTopic2")
                        .HasMaxLength(50);

                    b.Property<string>("Theme");

                    b.HasKey("Id");

                    b.ToTable("Plan");
                });
#pragma warning restore 612, 618
        }
    }
}
