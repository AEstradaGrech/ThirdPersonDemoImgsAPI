﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThirdPersonDemoIMGsInfrasturcture.Context;

namespace ThirdPersonDemoIMGsInfrasturcture.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2020, 5, 13, 18, 36, 32, 234, DateTimeKind.Local).AddTicks(6710));

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
