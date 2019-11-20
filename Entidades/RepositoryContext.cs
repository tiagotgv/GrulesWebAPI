using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<AlunoGrupo> AlunosGrupo { get; set; }
    }
}
