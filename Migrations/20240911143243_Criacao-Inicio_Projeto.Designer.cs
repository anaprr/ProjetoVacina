﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoVacina.Models;

#nullable disable

namespace ProjetoVacina.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240911143243_Criacao-Inicio_Projeto")]
    partial class CriacaoInicio_Projeto
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjetoVacina.Models.Cadastro", b =>
                {
                    b.Property<int>("CadastroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CadastroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CadastroId"));

                    b.Property<int>("CadastroAnoNascimento")
                        .HasColumnType("int")
                        .HasColumnName("CadastroAnoNascimento");

                    b.Property<int>("CadastroCpf")
                        .HasColumnType("int")
                        .HasColumnName("CadastroCpf");

                    b.Property<int>("CadastroDiaNascimento")
                        .HasColumnType("int")
                        .HasColumnName("CadastroDiaNascimento");

                    b.Property<string>("CadastroEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CadastroEmail");

                    b.Property<int>("CadastroGenero")
                        .HasColumnType("int")
                        .HasColumnName("CadastroGenero");

                    b.Property<int>("CadastroMesNascimento")
                        .HasColumnType("int")
                        .HasColumnName("CadastroMesNascimento");

                    b.Property<int>("CadastroSenha")
                        .HasColumnType("int")
                        .HasColumnName("CadastroSenha");

                    b.Property<int>("FrequenciaVacinaId")
                        .HasColumnType("int");

                    b.HasKey("CadastroId");

                    b.HasIndex("FrequenciaVacinaId");

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("ProjetoVacina.Models.FrequenciaVacina", b =>
                {
                    b.Property<int>("FrequenciaVacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FrequenciaVacinaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FrequenciaVacinaId"));

                    b.Property<string>("FrequenciaVacinaDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FrequenciaVacinaDescricao ");

                    b.HasKey("FrequenciaVacinaId");

                    b.ToTable("FrequenciaVacina");
                });

            modelBuilder.Entity("ProjetoVacina.Models.IndicacaoGenero", b =>
                {
                    b.Property<int>("IndicacaoGeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IndicacaoGeneroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndicacaoGeneroId"));

                    b.Property<string>("IndicacaoGeneroDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IndicacaoGeneroDescricao ");

                    b.HasKey("IndicacaoGeneroId");

                    b.ToTable("IndicacaoGenero");
                });

            modelBuilder.Entity("ProjetoVacina.Models.IndicacaoIdade", b =>
                {
                    b.Property<int>("IndicacaoIdadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IndicacaoIdadeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IndicacaoIdadeId"));

                    b.Property<string>("IndicacaoIdadeDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IndicacaoIdadeDescricao ");

                    b.HasKey("IndicacaoIdadeId");

                    b.ToTable("IndicacaoIdade");
                });

            modelBuilder.Entity("ProjetoVacina.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LoginId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"));

                    b.Property<string>("LoginEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LoginEmail");

                    b.Property<int>("LoginSenha")
                        .HasColumnType("int")
                        .HasColumnName("LoginSenha");

                    b.HasKey("LoginId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("ProjetoVacina.Models.Vacina", b =>
                {
                    b.Property<int>("VacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VacinaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VacinaId"));

                    b.Property<int>("IndicacaoGeneroId")
                        .HasColumnType("int");

                    b.Property<int>("IndicacaoIdadeId")
                        .HasColumnType("int");

                    b.Property<string>("VacinaDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VacinaDescricao");

                    b.Property<string>("VacinaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VacinaNome");

                    b.HasKey("VacinaId");

                    b.HasIndex("IndicacaoGeneroId");

                    b.HasIndex("IndicacaoIdadeId");

                    b.ToTable("Vacina");
                });

            modelBuilder.Entity("ProjetoVacina.Models.Cadastro", b =>
                {
                    b.HasOne("ProjetoVacina.Models.FrequenciaVacina", "FrequenciaVacina")
                        .WithMany()
                        .HasForeignKey("FrequenciaVacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FrequenciaVacina");
                });

            modelBuilder.Entity("ProjetoVacina.Models.Vacina", b =>
                {
                    b.HasOne("ProjetoVacina.Models.IndicacaoGenero", "IndicacaoGenero")
                        .WithMany()
                        .HasForeignKey("IndicacaoGeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoVacina.Models.IndicacaoIdade", "IndicacaoIdade")
                        .WithMany()
                        .HasForeignKey("IndicacaoIdadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IndicacaoGenero");

                    b.Navigation("IndicacaoIdade");
                });
#pragma warning restore 612, 618
        }
    }
}
