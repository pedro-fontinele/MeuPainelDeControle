using System;
using System.Collections.Generic;
using MeuPainelDeControle.Models;

namespace MeuPainelDeControle.Models
{
    public class Estoque 
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int EstoqueProduto { get; set; }
        public string TipoEmbalagem { get; set; } 
    }
}
