﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartphoneShop.Data;

namespace SmartphoneShop.Migrations
{
    [DbContext(typeof(GadgetStoreContext))]
    [Migration("20200605194724_OrderMigrationFix")]
    partial class OrderMigrationFix
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

                    b.Property<float>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("real");

                    b.HasKey("GadgetId")
                        .HasName("Gadget_pkey");

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
#pragma warning restore 612, 618
        }
    }
}
