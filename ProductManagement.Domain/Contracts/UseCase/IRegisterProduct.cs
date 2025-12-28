using ProductManagement.Domain.Dto;
using ProductManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Contracts.UseCase
{
    public interface IRegisterProduct
    {
        bool IsRegistered(CreateProductRequest createProduct);
    }
}
