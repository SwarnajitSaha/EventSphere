﻿// <auto-generated />
using System;
using EventSphere.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventSphere.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240409140419_MessageStatusAdd")]
    partial class MessageStatusAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventSphere.Models.Models.ContectUS", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContectUs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "I Love your Program very much.",
                            Email = "Jon@gmail.com",
                            Name = "Jon Doe",
                            Phone = "01789545215",
                            Status = "unread"
                        });
                });

            modelBuilder.Entity("EventSphere.Models.Models.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaxGuest")
                        .HasColumnType("int");

                    b.Property<int?>("MinGuest")
                        .HasColumnType("int");

                    b.Property<string>("Offer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EventCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Package for family get together.",
                            MaxGuest = 30,
                            MinGuest = 10,
                            Offer = "No available offer.",
                            Title = "Basic Birthday",
                            Type = "Birthday"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Package for official Conference.",
                            MaxGuest = 100,
                            MinGuest = 20,
                            Offer = "No available offer.",
                            Title = "Formal Conference",
                            Type = "Conference"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
