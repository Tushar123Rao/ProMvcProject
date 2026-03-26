using System;
using System.Collections.Generic;
using System.Text;
using ProMvcProject.Web.DTOs;

namespace ProMvcProject.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAvailableProductsAsync();
    }
}
