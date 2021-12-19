using System;
using System.Collections.Generic;

namespace MeuPainelDeControle.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string DescricaoProduto { get; set; }
        public double PrecoProduto { get; set; }
        public string TipoEmbalagem { get; set; }
        public double QuantidadeEmbalagem { get; set; }
    }
}
