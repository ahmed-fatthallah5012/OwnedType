﻿// <auto-generated />
using System;
using ConsoleApp2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20220123103129_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsoleApp2.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("ConsoleApp2.Models.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Journal", (string)null);
                });

            modelBuilder.Entity("ConsoleApp2.Models.Journal", b =>
                {
                    b.OwnsOne("ConsoleApp2.Models.Classifications", "BrandA", b1 =>
                        {
                            b1.Property<Guid>("JournalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("BrandId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("BrandA.BrandId");

                            b1.Property<decimal>("Qty")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("JournalId");

                            b1.HasIndex("BrandId");

                            b1.ToTable("Journal", (string)null);

                            b1.HasOne("ConsoleApp2.Models.Brand", "Brand")
                                .WithMany()
                                .HasForeignKey("BrandId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired()
                                .HasConstraintName("FK_BrandA_Journal_Brand.xD");

                            b1.WithOwner()
                                .HasForeignKey("JournalId");

                            b1.Navigation("Brand");
                        });

                    b.OwnsOne("ConsoleApp2.Models.Classifications", "BrandB", b1 =>
                        {
                            b1.Property<Guid>("JournalId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("BrandId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("BrandB.BrandId");

                            b1.Property<decimal>("Qty")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("JournalId");

                            b1.HasIndex("BrandId");

                            b1.ToTable("Journal", (string)null);

                            b1.HasOne("ConsoleApp2.Models.Brand", "Brand")
                                .WithMany()
                                .HasForeignKey("BrandId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired()
                                .HasConstraintName("FK_BrandB_Journal_Brand.xD");

                            b1.WithOwner()
                                .HasForeignKey("JournalId");

                            b1.Navigation("Brand");
                        });

                    b.Navigation("BrandA")
                        .IsRequired();

                    b.Navigation("BrandB")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}