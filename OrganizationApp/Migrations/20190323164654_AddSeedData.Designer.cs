﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrganizationApp.Data;

namespace OrganizationApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190323164654_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OrganizationApp.Models.ChoreItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssignedTo");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("choreItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedTo = "Adam",
                            CreatedDate = new DateTime(2019, 3, 23, 12, 46, 54, 556, DateTimeKind.Local).AddTicks(6060),
                            IsComplete = false,
                            Name = "Dishes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
