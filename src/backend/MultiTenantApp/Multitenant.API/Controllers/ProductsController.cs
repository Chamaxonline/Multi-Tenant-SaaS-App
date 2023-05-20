using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multitenant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            return Ok(productDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductRequest request)
        {
            try
            {
                return Ok(await _service.CreateAsync(request.Name, request.Description, request.Rate));
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
            
        }
    }
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
    }
}
