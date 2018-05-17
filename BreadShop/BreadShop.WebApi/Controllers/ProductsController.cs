using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BreadShop.Application.Services.Product;
using BreadShop.Application.Dtos.Product;
using BreadShop.Domain.Products.Model;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreadShop.WebApi.Controllers
{
    /// <summary>
    /// product controller class that implements server side api end points.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Products")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductsController(IProductApplicationService productApplicationService)
        {
            this._productApplicationService = productApplicationService;
        }
 
        /// <summary>
        /// saving product object.
        /// </summary>
        /// <param name="product">product object that want to save</param>
        /// <returns>result</returns>
        [HttpPost]
        public IActionResult Post([FromBody]ProductDto product)
        {
            if (!ModelState.IsValid || product == null)
            {
                return BadRequest(ModelState);
            }
            Product result = _productApplicationService.SaveProduct(product);
            return Created("", result);
        }

        /// <summary>
        /// get all product list
        /// </summary>
        /// <returns>product list</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductDto>), 200)]
        public IActionResult Get()
        {
            IEnumerable<ProductDto> products = new List<ProductDto>();

            products = _productApplicationService.GetProducts();

            if (!products.Any())
            {
                return NotFound();
            }

            return Ok(products);
        }

        /// <summary>
        /// updating product object.
        /// </summary>
        /// <param name="productDto">productdto object</param>
        /// <returns>IAction result</returns>
        [HttpPut]
        public IActionResult Put([FromBody]ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(ModelState);
            }
            _productApplicationService.UpdateProduct(productDto);
            return Ok();
        }

        /// <summary>
        /// get product details by Id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>product details</returns>
        [HttpGet("{id}")]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            if (id != 0)
            {
                ProductDto stock = _productApplicationService.GetProductById(id);
                return Ok(stock);
            }
            return BadRequest();
        }
    }
}
