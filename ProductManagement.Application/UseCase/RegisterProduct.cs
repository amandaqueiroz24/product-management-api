using ProductManagement.Domain.Contracts;
using ProductManagement.Domain.Contracts.Repository;
using ProductManagement.Domain.Contracts.UseCase;
using ProductManagement.Domain.Dto;
using ProductManagement.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.UseCase
{
    public class RegisterProduct : IRegisterProduct
    {
        public IProductRepository productRepository;
        public RegisterProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public bool IsRegistered(CreateProductRequest createProduct)
        {
            if (createProduct != null)
            {
                if(productRepository.InsertAsync(createProduct) != null)
                    return true;
            }
            return false;
        }
    }
}
