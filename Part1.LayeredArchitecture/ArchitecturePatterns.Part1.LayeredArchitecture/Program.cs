using System.Text.Json;
using ArchitecturePatterns.Part1.LayeredArchitecture.Business;
using ArchitecturePatterns.Part1.LayeredArchitecture.Data;
using ArchitecturePatterns.Part1.LayeredArchitecture.Presentation;

var repo = new ProductRepo();
var productService = new ProductService(repo);
var productController = new ProductController(productService);


Console.WriteLine("Trying to retrieve the product for Id = 1...");
var foundProduct = productController.GetProduct(1);
Console.WriteLine($"The product returned is: {JsonSerializer.Serialize(foundProduct)}");

var createProductRequest = new ProductCreateDto
{
    Name = "Dji Mavic 3",
    Price = 10000000
};

Console.WriteLine("Trying to create a new product...");
var createdProduct = productController.PostProduct(createProductRequest);
Console.WriteLine($"The product that was created is: {JsonSerializer.Serialize(createdProduct)}");


Console.WriteLine("Trying to retrieve the product for Id = 1 again...");
var subsequentlyFoundProduct = productController.GetProduct(1);
Console.WriteLine($"The product returned is: {JsonSerializer.Serialize(subsequentlyFoundProduct)}");
