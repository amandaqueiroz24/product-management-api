using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Model
{
    public class Product
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string? Url { get; private set; }
        public decimal Valor { get; private set; }

        public Product(string nome, string? url, decimal valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("O nome do produto não pode ser nulo ou vazio.", nameof(nome));

            if (valor < 0)
                throw new ArgumentException("O valor do produto não pode ser negativo.", nameof(valor));

            Nome = nome;
            Url = url;
            Valor = valor;
        }

        // Construtor privado para uso do Dapper/EF Core
        private Product() { }

        public void SetId(int id)
        {
            if (Id != 0)
                throw new InvalidOperationException("O Id do produto já foi definido.");
            if (id <= 0)
                throw new ArgumentException("O Id do produto deve ser um número positivo.", nameof(id));

            Id = id;
        }
    }
}
