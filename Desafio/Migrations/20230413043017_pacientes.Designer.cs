﻿// <auto-generated />
using System;
using Desafio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio.Migrations
{
    [DbContext(typeof(ConsultorioContexto))]
    [Migration("20230413043017_pacientes")]
    partial class pacientes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Desafio.Model.Paciente", b =>
                {
                    b.Property<long>("CPF")
                        .HasColumnType("bigint")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("Date")
                        .HasColumnName("data_de_nascimento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("CPF")
                        .HasName("pk_pacientes");

                    b.ToTable("pacientes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}