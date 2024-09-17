using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Console_Produtos.Enum;

namespace Teste_Console_Produtos.Model
{
    public class Produto
    {
        public string Descricao { get; set; }
        public double ValorVenda { get; set; }
        public double ValorCompra { get; set; }
        public TipoProduto Tipo { get; set; }
        public DateTime DataCriacao { get; set; }

        public double MargemLucro => ValorVenda - ValorCompra;
    }
}
