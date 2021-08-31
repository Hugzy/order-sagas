﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RebusTest.EFCore;

namespace RebusTest.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20210816125931_principal_dependant_entity")]
    partial class principal_dependant_entity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.DependantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("PrincipalEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("PrincipalEntityId")
                        .IsUnique();

                    b.ToTable("DependantEntities");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.Foo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("TestId")
                        .IsUnique();

                    b.ToTable("Foos");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.PrincipalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntities");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.DependantEntity", b =>
                {
                    b.HasOne("RebusTest.EFCore.Models.DbModels.PrincipalEntity", "PrincipalEntity")
                        .WithOne("DependantEntities")
                        .HasForeignKey("RebusTest.EFCore.Models.DbModels.DependantEntity", "PrincipalEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrincipalEntity");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.Foo", b =>
                {
                    b.HasOne("RebusTest.EFCore.Models.DbModels.Test", "Test")
                        .WithOne("Foo")
                        .HasForeignKey("RebusTest.EFCore.Models.DbModels.Foo", "TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.PrincipalEntity", b =>
                {
                    b.Navigation("DependantEntities");
                });

            modelBuilder.Entity("RebusTest.EFCore.Models.DbModels.Test", b =>
                {
                    b.Navigation("Foo");
                });
#pragma warning restore 612, 618
        }
    }
}
