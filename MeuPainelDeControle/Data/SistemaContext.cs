using System;
using MeuPainelDeControle.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuPainelDeControle.Data
{
    public class SistemaContext : DbContext
    {
        public SistemaContext(DbContextOptions<SistemaContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Estoque>().ToTable("Estoque");
        }
    }
}
