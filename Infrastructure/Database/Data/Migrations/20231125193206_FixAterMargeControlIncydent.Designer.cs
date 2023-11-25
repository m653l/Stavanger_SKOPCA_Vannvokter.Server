﻿// <auto-generated />
using System;
using Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Database.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231125193206_FixAterMargeControlIncydent")]
    partial class FixAterMargeControlIncydent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Domain.Aggregates.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FarmName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("isPies")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("Domain.Aggregates.Submition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfExecution")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProducerId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("SubmitionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubmitionType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Submition");
                });

            modelBuilder.Entity("Domain.Aggregates.Producer", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Address", "FarmAddress", b1 =>
                        {
                            b1.Property<int>("ProducerId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ProducerId");

                            b1.ToTable("Producers");

                            b1.WithOwner()
                                .HasForeignKey("ProducerId");
                        });

                    b.Navigation("FarmAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.Submition", b =>
                {
                    b.HasOne("Domain.Aggregates.Producer", "Producer")
                        .WithMany("Submitions")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Address", "FieldAddress", b1 =>
                        {
                            b1.Property<int>("SubmitionId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("SubmitionId");

                            b1.ToTable("Submition");

                            b1.WithOwner()
                                .HasForeignKey("SubmitionId");
                        });

                    b.Navigation("FieldAddress")
                        .IsRequired();

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Domain.Aggregates.Producer", b =>
                {
                    b.Navigation("Submitions");
                });
#pragma warning restore 612, 618
        }
    }
}
