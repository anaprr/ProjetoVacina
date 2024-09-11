using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ProjetoVacina.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<Cadastro> Cadastro { get; set; }

        public DbSet<Login> Login { get; set; }

        public DbSet<Vacina> Vacina { get; set; }

        public DbSet<FrequenciaVacina> FrequenciaVacina { get; set; }

        public DbSet<IndicacaoGenero> IndicacaoGenero { get; set; }

        public DbSet<IndicacaoIdade> IndicacaoIdade { get; set; }

    }
       
}

