using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Produto.Model
{
    public class ProdutoModel
    {
        public Guid Id { get; init; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }

        public ProdutoModel(string nome, decimal preco, int estoque)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }
    }
}
