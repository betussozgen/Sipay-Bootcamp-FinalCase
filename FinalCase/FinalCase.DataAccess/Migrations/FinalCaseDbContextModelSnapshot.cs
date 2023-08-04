﻿// <auto-generated />
using System;
using FinalCase.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalCase.DataAccess.Migrations
{
    [DbContext(typeof(FinalCaseDbContext))]
    partial class FinalCaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApartmentNo")
                        .HasColumnType("integer")
                        .HasColumnName("ApartmentNo");

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Block");

                    b.Property<int>("FloorNo")
                        .HasColumnType("integer")
                        .HasColumnName("FloorNo");

                    b.Property<string>("OwnerOrTenant")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("OwnerOrTenant");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Type");

                    b.HasKey("Id");

                    b.ToTable("Apartment", "dbo");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Amount");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("ApartmentId");

                    b.Property<int>("Month")
                        .HasColumnType("integer")
                        .HasColumnName("Month");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("Year");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Bill", "dbo");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Due", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Amount");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("integer")
                        .HasColumnName("ApartmentId");

                    b.Property<int>("Month")
                        .HasColumnType("integer")
                        .HasColumnName("Month");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("Year");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Due", "dbo");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Amount");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("PaymentDate");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("integer")
                        .HasColumnName("PaymentMethod");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Payment", "dbo");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Role", "dbo");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("CarInfo")
                        .HasColumnType("boolean")
                        .HasColumnName("CarInfo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("RoleID")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Surname");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("TcNo");

                    b.HasKey("Id");

                    b.HasIndex("RoleID");

                    b.HasIndex("TcNo")
                        .IsUnique();

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Bill", b =>
                {
                    b.HasOne("FinalCase.DataAccess.Domain.Apartment", "Apartments")
                        .WithMany("Bill")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Due", b =>
                {
                    b.HasOne("FinalCase.DataAccess.Domain.Apartment", "Apartments")
                        .WithMany("Dues")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartments");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Payment", b =>
                {
                    b.HasOne("FinalCase.DataAccess.Domain.User", "Users")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.User", b =>
                {
                    b.HasOne("FinalCase.DataAccess.Domain.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Apartment", b =>
                {
                    b.Navigation("Bill");

                    b.Navigation("Dues");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FinalCase.DataAccess.Domain.User", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
