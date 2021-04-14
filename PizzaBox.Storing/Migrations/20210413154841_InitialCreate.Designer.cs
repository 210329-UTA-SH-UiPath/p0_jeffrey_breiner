﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20210413154841_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBCrust", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CRUST")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("DBCrusts");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBCustomer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DBCustomers");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DBCustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("DBStoreID")
                        .HasColumnType("int");

                    b.Property<decimal?>("PriceTotal")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("DBCustomerID");

                    b.HasIndex("DBStoreID");

                    b.ToTable("DBOrders");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBPizza", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DBCrustID")
                        .HasColumnType("int");

                    b.Property<int?>("DBOrderID")
                        .HasColumnType("int");

                    b.Property<int?>("DBSizeID")
                        .HasColumnType("int");

                    b.Property<int>("PIZZA")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("DBCrustID");

                    b.HasIndex("DBOrderID");

                    b.HasIndex("DBSizeID");

                    b.ToTable("DBPizzas");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBSize", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SIZE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DBSizes");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBStore", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("STORE")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("DBStores");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBTopping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DBPizzaID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TOPPING")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DBPizzaID");

                    b.ToTable("DBToppings");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBOrder", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.EntityModels.DBCustomer", "DBCustomer")
                        .WithMany()
                        .HasForeignKey("DBCustomerID");

                    b.HasOne("PizzaBox.Storing.Entities.EntityModels.DBStore", "DBStore")
                        .WithMany()
                        .HasForeignKey("DBStoreID");

                    b.Navigation("DBCustomer");

                    b.Navigation("DBStore");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBPizza", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.EntityModels.DBCrust", "DBCrust")
                        .WithMany()
                        .HasForeignKey("DBCrustID");

                    b.HasOne("PizzaBox.Storing.Entities.EntityModels.DBOrder", null)
                        .WithMany("Pizzas")
                        .HasForeignKey("DBOrderID");

                    b.HasOne("PizzaBox.Storing.Entities.EntityModels.DBSize", "DBSize")
                        .WithMany()
                        .HasForeignKey("DBSizeID");

                    b.Navigation("DBCrust");

                    b.Navigation("DBSize");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBTopping", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.EntityModels.DBPizza", null)
                        .WithMany("DBToppings")
                        .HasForeignKey("DBPizzaID");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBOrder", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.EntityModels.DBPizza", b =>
                {
                    b.Navigation("DBToppings");
                });
#pragma warning restore 612, 618
        }
    }
}