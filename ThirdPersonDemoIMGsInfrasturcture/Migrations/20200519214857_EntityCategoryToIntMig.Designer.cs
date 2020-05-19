﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThirdPersonDemoIMGsInfrasturcture.Context;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200519214857_EntityCategoryToIntMig")]
    partial class EntityCategoryToIntMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ThirdPersonDemoIMGsDomain.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2020, 5, 19, 23, 48, 57, 92, DateTimeKind.Local).AddTicks(710));

                    b.Property<string>("GameStudioName");

                    b.Property<byte[]>("ImgBytes")
                        .IsRequired();

                    b.Property<string>("ImgName")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ImgName")
                        .IsUnique();

                    b.ToTable("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
