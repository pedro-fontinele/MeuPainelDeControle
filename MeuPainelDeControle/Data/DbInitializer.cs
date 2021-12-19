using MeuPainelDeControle.Models;
using MeuPainelDeControle.Data;
using System;
using System.Linq;

namespace MeuPainelDeControle.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SistemaContext context)
        {
            context.Database.EnsureCreated();

            //verifica se tabela existe se nao cria ele vazia
            //if (context.Produtos.Any())
            //{
            //    return;
            //}
            //var produto = new Produto[] { };
            //foreach (Produto s in produto)
            //{
            //    context.Produtos.Add(s);
            //}
            //context.SaveChanges();

            // verifica se tabela existe se nao cria ele vazia
            //if (context.Estoques.Any())
            //{
            //    return;
            //}
            //var estoques = new Estoque[] {};
            //foreach (Estoque s in estoques)
            //{
            //    context.Estoques.Add(s);
            //}
            //context.SaveChanges();
        }
    }
}