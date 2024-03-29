﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20210116062633_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LstDogId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("LstDogId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Core.Entities.LstDefault", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KeyIndex")
                        .HasColumnType("TEXT");

                    b.Property<int>("LstTypeClass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LstTypeItem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("LstDefaults");
                });

            modelBuilder.Entity("Core.Entities.LstDog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DogAuthor")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KeyIndex")
                        .HasColumnType("TEXT");

                    b.Property<int>("LstTypeClass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LstTypeItem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("LstDogs");
                });

            modelBuilder.Entity("Core.Entities.LstOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("KeyIndex")
                        .HasColumnType("TEXT");

                    b.Property<int>("LstTypeClass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LstTypeItem")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderCode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("LstOrders");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Department", b =>
                {
                    b.HasOne("Core.Entities.LstDog", "LstDog")
                        .WithMany("Departments")
                        .HasForeignKey("LstDogId");
                });

            modelBuilder.Entity("Core.Entities.LstDefault", b =>
                {
                    b.HasOne("Core.Entities.LstDefault", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Core.Entities.LstDog", b =>
                {
                    b.HasOne("Core.Entities.LstDog", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Core.Entities.LstOrder", b =>
                {
                    b.HasOne("Core.Entities.LstOrder", "Parent")
                        .WithMany("Childrens")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
