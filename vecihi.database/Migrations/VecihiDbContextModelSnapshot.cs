﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vecihi.database;

namespace vecihi.database.Migrations
{
    [DbContext(typeof(VecihiDbContext))]
    partial class VecihiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vecihi.database.model.AutoCodeLogModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AutoCodeId");

                    b.Property<DateTime>("CodeGenerationDate");

                    b.Property<int>("CodeNumber");

                    b.Property<Guid>("GeneratedBy");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("AutoCodeId");

                    b.HasIndex("GeneratedBy");

                    b.ToTable("AutoCodeLog");
                });

            modelBuilder.Entity("vecihi.database.model.AutoCodeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeFormat")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("LastCodeNumber");

                    b.Property<string>("ScreenCode")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("AutoCode");
                });

            modelBuilder.Entity("vecihi.database.model.FileModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<Guid>("RefId");

                    b.Property<string>("ScreenCode")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<long?>("Size");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("vecihi.database.model.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<Guid>("CreatedBy");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ExternalAuthId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<Guid?>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c5337a5-ca82-4c97-94e9-00101a1d749d"),
                            CreatedAt = new DateTime(2019, 8, 27, 17, 0, 20, 419, DateTimeKind.Local).AddTicks(564),
                            CreatedBy = new Guid("0c5337a5-ca82-4c97-94e9-00101a1d749d"),
                            ExternalAuthId = new Guid("7cbf9971-7957-48dd-8198-3394a9bf0059"),
                            IsDeleted = false,
                            Name = "qnill"
                        });
                });

            modelBuilder.Entity("vecihi.database.model.AutoCodeLogModel", b =>
                {
                    b.HasOne("vecihi.database.model.AutoCodeModel", "AutoCode")
                        .WithMany("AutoCodeLogs")
                        .HasForeignKey("AutoCodeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("vecihi.database.model.UserModel", "User")
                        .WithMany("AutoCodeLogs")
                        .HasForeignKey("GeneratedBy")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}