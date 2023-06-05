using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitecturePatterns.Part1.LayeredArchitecture.Business;

namespace ArchitecturePatterns.Part1.LayeredArchitecture.Data
{
    public class ProductRepo
    {
        private List<ProductPm> _products;

        public ProductRepo()
        {
            _products = new();
        }
        
        public ProductBm CreateProduct(ProductBm product)
        {
            var createdProduct = new ProductPm
            {
                Id = _products.Count + 1,
                Name = product.Name,
                Price = product.Price
            };

            _products.Add(createdProduct);

            return new ProductBm
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Price = createdProduct.Price
            };
        }

        public ProductBm? QueryProductById(int id)
        {
            var productPm = _products.SingleOrDefault(p => p.Id == id);
            return productPm == null ? null : new ProductBm
            {
                Id = productPm.Id,
                Name = productPm.Name,
                Price = productPm.Price
            };
        }
    }
}
