﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartphoneShop.Data;

namespace SmartphoneShop.Migrations
{
    [DbContext(typeof(GadgetStoreContext))]
    [Migration("20200605194604_OrderMigration")]
    partial class OrderMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SmartphoneShop.Models.Gadget", b =>
                {
                    b.Property<int>("GadgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("character varying");

                    b.Property<string>("Image")
                        .HasColumnName("Image")
                        .HasColumnType("character varying");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasColumnType("character varying");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("real");

                    b.HasKey("GadgetId")
                        .HasName("Gadget_pkey");

                    b.HasIndex("OrderId");

                    b.ToTable("Gadgets");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GadgetId")
                        .HasColumnName("GadgetId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId")
                        .HasColumnType("text");

                    b.HasKey("OrderId")
                        .HasName("order_pkey");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SmartphoneShop.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SmartphoneShop.Models.Gadget", b =>
                {
                    b.HasOne("SmartphoneShop.Models.Order", null)
                        .WithMany("Gadgets")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("SmartphoneShop.Models.User", b =>
                {
                    b.HasOne("SmartphoneShop.Models.Order", null)
                        .WithMany("Users")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
