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

        public async Task<int> ExecuteAsync(CreateProductRequest createProductRequest)
        {
            if (createProductRequest == null)
            {
                throw new ArgumentNullException(nameof(createProductRequest));
            }

            var product = new Product(
                createProductRequest.Name,
                createProductRequest.Url,
                createProductRequest.Price,
                "S"

            );

            var productId = await productRepository.InsertAsync(product);

            return productId;
        }
    }
}
