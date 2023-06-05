using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitecturePatterns.Part1.LayeredArchitecture.Business;

namespace ArchitecturePatterns.Part1.LayeredArchitecture.Presentation;
public class ProductController
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public ProductGetDto PostProduct(ProductCreateDto productCreateRequest)
    {
        return _productService.CreateProduct(productCreateRequest);
    }

    public ProductGetDto? GetProduct(int id)
    {
        return _productService.QueryProductById(id);
    }
}

