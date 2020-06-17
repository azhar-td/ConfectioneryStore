﻿// <auto-generated />
using System;
using ConfectioneryStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConfectioneryStore.Migrations
{
    [DbContext(typeof(ConfectioneryDbContext))]
    [Migration("20200616160435_first--1 migration")]
    partial class first1migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConfectioneryStore.Models.Confectionery", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("PricePerItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.HasKey("IdConfectionery")
                        .HasName("Confectionery_PK");

                    b.ToTable("Confectionery");
                });

            modelBuilder.Entity("ConfectioneryStore.Models.ConfectioneryOrder", b =>
                {
                    b.Property<int>("IdConfectionery")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int?>("ConfectioneryIdConfectionery")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("OrderIdOrder")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdConfectionery", "IdOrder");

                    b.HasIndex("ConfectioneryIdConfectionery");

                    b.HasIndex("OrderIdOrder");

                    b.ToTable("ConfectioneryOrder");
                });

            modelBuilder.Entity("ConfectioneryStore.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdCustomer")
                        .HasName("Customer_PK");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("ConfectioneryStore.Models.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdEmployee")
                        .HasName("Employee_PK");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ConfectioneryStore.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("IdOrder")
                        .HasName("Order_PK");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdEmployee");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ConfectioneryStore.Models.ConfectioneryOrder", b =>
                {
                    b.HasOne("ConfectioneryStore.Models.Confectionery", "Confectionery")
                        .WithMany("ConfectioneryOrders")
                        .HasForeignKey("ConfectioneryIdConfectionery");

                    b.HasOne("ConfectioneryStore.Models.Order", "Order")
                        .WithMany("ConfectioneryOrders")
                        .HasForeignKey("OrderIdOrder");
                });

            modelBuilder.Entity("ConfectioneryStore.Models.Order", b =>
                {
                    b.HasOne("ConfectioneryStore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("IdCustomer")
                        .HasConstraintName("Order_Customer_FK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConfectioneryStore.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmployee")
                        .HasConstraintName("Order_Employee_FK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
