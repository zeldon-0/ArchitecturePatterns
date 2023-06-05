using ArchitecturePatterns.Part1.LayeredArchitecture.Business;
using ArchitecturePatterns.Part1.LayeredArchitecture.Data;
using ArchitecturePatterns.Part1.LayeredArchitecture.Presentation;
using FluentAssertions;

namespace ArchitecturePatterns.Part1.LayeredArchitecture.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public void GetProduct_should_return_null_for_non_existent_product()
        {
            // Arrange
            var repo = new ProductRepo();
            var productService = new ProductService(repo);
            var productController = new ProductController(productService);

            // Act
            var foundProduct = productController.GetProduct(1);

            // Assert
            foundProduct.Should().BeNull();
        }

        [Fact]
        public void GetProduct_should_return_previously_created_product()
        {
            // Arrange
            var repo = new ProductRepo();
            var productService = new ProductService(repo);
            var productController = new ProductController(productService);

            // Act
            var createProductRequest = new ProductCreateDto
            {
                Name = "Dji Mavic 3",
                Price = 10000000
            };

            var createdProduct = productController.PostProduct(createProductRequest);
            var foundProduct = productController.GetProduct(createdProduct.Id);

            // Assert
            foundProduct.Should().BeEquivalentTo(createdProduct);
        }
    }
}