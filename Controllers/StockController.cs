using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock_Market_WebAPI.Data;
using Stock_Market_WebAPI.Dtos.Stock;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Mappers;

namespace Stock_Market_WebAPI.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepository.GetStocks();
            var stocksDto=  stocks.Select(x=>x.toStockDto());
            return Ok(stocksDto);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetStock([FromRoute] Guid id) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock= await _stockRepository.GetStock(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toStockDto() );
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.toStockModel();
             await _stockRepository.AddStock(stockModel);
            return CreatedAtAction(nameof(GetStock), new { id = stockModel.Id }, stockModel.toStockDto());
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateStock([FromRoute] Guid id,[FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock =await _stockRepository.UpdateStock(id, updateDto);


            if (stock == null)
            {
                return NotFound();
            }
           
            return Ok(stock.toStockDto());
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStock([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepository.DeleteStock(id);
            if (stock == null)
            {
                return NotFound("Stock not found");
            }


            return Ok(stock.toStockDto());



        }
    }
}
