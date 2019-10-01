﻿// <auto-generated />
using System;
using DataPlus.Bar.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataPlus.Bar.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20190925230836_UpdateCubeModel")]
    partial class UpdateCubeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataPlus.Bar.Entities.Models.ArrayValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CubeId");

                    b.Property<int>("Value");

                    b.Property<int>("X");

                    b.Property<int>("Y");

                    b.Property<int>("Z");

                    b.HasKey("Id");

                    b.HasIndex("CubeId");

                    b.ToTable("ArrayValue");
                });

            modelBuilder.Entity("DataPlus.Bar.Entities.Models.Cube", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.ToTable("Cubes");
                });

            modelBuilder.Entity("DataPlus.Bar.Entities.Models.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Level");

                    b.Property<string>("Logger");

                    b.Property<string>("Message");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DataPlus.Bar.Entities.Models.ArrayValue", b =>
                {
                    b.HasOne("DataPlus.Bar.Entities.Models.Cube", "Cube")
                        .WithMany("Array")
                        .HasForeignKey("CubeId");
                });
#pragma warning restore 612, 618
        }
    }
}
