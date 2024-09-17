using Newtonsoft.Json;
using System;
using System.Text;
using Teste_Console_Produtos.Enum;
using Teste_Console_Produtos.Model;

namespace Teste_Console_Produtos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a lista de produtos em formato JSON:");
            StringBuilder jsonInput = new StringBuilder();
            string line;
            
            while (!String.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                jsonInput.AppendLine(line);
            }

            var produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonInput.ToString());

            if (produtos == null || produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto foi fornecido.");
                return;
            }

            //Obtem os produtos validos
            var produtosValidos = produtos.Where(p =>
                p.ValorVenda > p.ValorCompra &&
                p.DataCriacao >= new DateTime(2024, 1, 1) &&
                p.Descricao.Length >= 5 &&
                p.ValorCompra > 0 && p.ValorVenda > 0
            ).ToList();

            // Filtrar produtos criados no segundo trimestre de 2024
            var produtosSegundoTrimestre = produtosValidos
                .Where(p => p.DataCriacao >= new DateTime(2024, 4, 1) && p.DataCriacao <= new DateTime(2024, 6, 30))
                .ToList();


            // Ordenar produtos
            var produtosOrdenadosPorTipo = produtosSegundoTrimestre
                .OrderBy(p => p.Tipo)
                .ToList();

            // Exibir top 3 produtos com maior margem de lucro
            var topProdutosPorMargem = produtosValidos
                .OrderByDescending(p => p.MargemLucro)
                .Take(3)
                .ToList();

            // Exibir os produtos filtrados do segundo trimestre
            if (produtosOrdenadosPorTipo.Count > 0)
            {
                Console.WriteLine("\nProdutos criados no segundo trimestre de 2024:");
                foreach (var produto in produtosOrdenadosPorTipo)
                {
                    Console.WriteLine($"Descrição: {produto.Descricao}, Tipo: {produto.Tipo}, Data de Criação: {produto.DataCriacao.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("\nNenhum produto foi criado no segundo trimestre de 2024.");
            }

            // Exibir o top 3 produtos com maior margem de lucro
            if (topProdutosPorMargem.Count > 0)
            {
                Console.WriteLine("\nTop 3 produtos com maior margem de lucro:");
                foreach (var produto in topProdutosPorMargem)
                {
                    Console.WriteLine($"Descrição: {produto.Descricao}, Margem de Lucro: {produto.MargemLucro}, Tipo: {produto.Tipo}, Valor de Venda: {produto.ValorVenda}, Valor de Compra: {produto.ValorCompra}");
                }
            }
            else
            {
                Console.WriteLine("\nNenhum produto válido para exibir o Top 3.");
            }
        }


   //Lista para Exemplo.
        /*
        [
  {
    "Descricao": "Produto A",
    "ValorVenda": 150,
    "ValorCompra": 100,
    "Tipo": 1,
    "DataCriacao": "2024-04-15T00:00:00"
  },
  {
    "Descricao": "Produto B",
    "ValorVenda": 120,
    "ValorCompra": 80,
    "Tipo": 2,
    "DataCriacao": "2024-05-20T00:00:00"
  },
  {
    "Descricao": "ProdC",
    "ValorVenda": 200,
    "ValorCompra": 50,
    "Tipo": 3,
    "DataCriacao": "2023-12-25T00:00:00"
  },
  {
    "Descricao": "Produto D",
    "ValorVenda": 500,
    "ValorCompra": 300,
    "Tipo": 4,
    "DataCriacao": "2024-06-05T00:00:00"
  },
  {
    "Descricao": "Produto E",
    "ValorVenda": 250,
    "ValorCompra": 150,
    "Tipo": 1,
    "DataCriacao": "2024-04-20T00:00:00"
  },
  {
    "Descricao": "Produto F",
    "ValorVenda": 220,
    "ValorCompra": 170,
    "Tipo": 2,
    "DataCriacao": "2024-05-30T00:00:00"
  },
  {
    "Descricao": "Produto G",
    "ValorVenda": 600,
    "ValorCompra": 400,
    "Tipo": 3,
    "DataCriacao": "2024-06-10T00:00:00"
  },
  {
    "Descricao": "Produto H",
    "ValorVenda": 350,
    "ValorCompra": 200,
    "Tipo": 4,
    "DataCriacao": "2024-03-05T00:00:00"
  },
  {
    "Descricao": "Produto I",
    "ValorVenda": 300,
    "ValorCompra": 100,
    "Tipo": 1,
    "DataCriacao": "2024-04-01T00:00:00"
  },
  {
    "Descricao": "Produto J",
    "ValorVenda": 180,
    "ValorCompra": 140,
    "Tipo": 2,
    "DataCriacao": "2024-05-10T00:00:00"
  }
]

        */
    }
}