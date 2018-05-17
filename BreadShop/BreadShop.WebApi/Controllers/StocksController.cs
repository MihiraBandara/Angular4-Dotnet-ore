using BreadShop.Application.Services.Stock;
using Microsoft.AspNetCore.Mvc;
using BreadShop.Application.Dtos.Stock;
using Microsoft.AspNetCore.Authorization;

namespace BreadShop.WebApi.Controllers
{
    /// <summary>
    /// stock application service that implements server side api end point.
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    public class StocksController : Controller
    {
        private readonly IStockApplicationService _stockApplicationService;

        public StocksController(IStockApplicationService stockApplicationService)
        {
            this._stockApplicationService = stockApplicationService;
        }

        /// <summary>
        /// saving stock object
        /// </summary>
        /// <param name="stock">stock object that want to save</param>
        /// <returns>stock object</returns>
        [HttpPost]
        public IActionResult Post([FromBody]StockDto stock)
        {
            if (stock == null)
            {
                return BadRequest(ModelState);
            }
            _stockApplicationService.SaveStock(stock);
            return Created("api/stock", stock);
        }        

    }
}