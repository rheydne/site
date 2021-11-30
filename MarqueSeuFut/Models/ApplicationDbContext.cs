using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarqueSeuFut.Models;

namespace MarqueSeuFut.Models
{
    // classe para gerenciar a aplicação com o

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var cascadeFKs = builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(builder);
        }

        public DbSet<Posicao> Posicoes { get; set; } // tera esse atributo para todas as tabelas que serão criadas
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Escalacao> Escalacoes { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<MarqueSeuFut.Models.Estatistica> Estatistica { get; set; }

        public DbSet<Estatistica> Estatisticas { get; set; }

        public DbSet<Perfil> Perfis { get; set; }

        public DbSet<Pesquisa> Pesquisa { get; set; }

    }

}
