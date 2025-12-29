using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Dto
{
    public class CreateProductRequest
    {
        public string Nome { get; set; }
        public string Url { get; set; }
        public decimal Valor { get; set; }
    }
}
