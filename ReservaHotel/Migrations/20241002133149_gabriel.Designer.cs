﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservaHotel.Repositories.Data;

#nullable disable

namespace ReservaHotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20241002133149_gabriel")]
    partial class gabriel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ReservaHotel.Models.Hospede", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Hospedes");
                });

            modelBuilder.Entity("ReservaHotel.Models.Quarto", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("ReservaHotel.Models.Reserva", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<int>("HospedeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuartoId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HospedeId");

                    b.HasIndex("QuartoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ReservaHotel.Models.Reserva", b =>
                {
                    b.HasOne("ReservaHotel.Models.Hospede", "Hospede")
                        .WithMany()
                        .HasForeignKey("HospedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaHotel.Models.Quarto", "Quarto")
                        .WithMany()
                        .HasForeignKey("QuartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospede");

                    b.Navigation("Quarto");
                });
#pragma warning restore 612, 618
        }
    }
}
