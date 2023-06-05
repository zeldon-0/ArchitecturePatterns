using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitecturePatterns.Part1.LayeredArchitecture.Data;
using ArchitecturePatterns.Part1.LayeredArchitecture.Presentation;

namespace ArchitecturePatterns.Part1.LayeredArchitecture.Business
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo;

        public ProductService(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public ProductGetDto CreateProduct(ProductCreateDto productCreateRequest)
        {
            var productBm = new ProductBm
            {
                Name = productCreateRequest.Name,
                Price = productCreateRequest.Price
            };

            var createdProduct = _productRepo.CreateProduct(productBm);

            return new ProductGetDto
            {
                Id = createdProduct.Id!.Value,
                Name = createdProduct.Name,
                Price = createdProduct.Price
            };
        }

        public ProductGetDto? QueryProductById(int id)
        {
            var productBm  = _productRepo.QueryProductById(id);
            return productBm == null ? null : new ProductGetDto
            {
                Id = productBm.Id!.Value,
                Name = productBm.Name,
                Price = productBm.Price
            };
        }
    }
}
