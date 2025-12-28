using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Url { get; set; }
        public decimal Valor { get; set; }
    }
}
