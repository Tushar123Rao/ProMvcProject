using System;
using System.Collections.Generic;
using System.Text;
using ProMvcProject.Domain.Interfaces;
using ProMvcProject.Web.DTOs;

namespace ProMvcProject.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAvailableProductAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }
    }
}
