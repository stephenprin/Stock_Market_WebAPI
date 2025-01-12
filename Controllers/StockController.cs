using Microsoft.AspNetCore.Mvc;
using Stock_Market_WebAPI.Data;
using Stock_Market_WebAPI.Dtos.Stock;
using Stock_Market_WebAPI.Mappers;

namespace Stock_Market_WebAPI.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStocks()
        {
           var stocks = _context.Stocks.ToList().Select(x=>x.toStockDto());
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public IActionResult GetStock([FromRoute]int id) { 
            var stock= _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.toStockDto() );
        }

        [HttpPost]
        public IActionResult AddStock([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.toStockModel();
            var stock = _context.Stocks.Add(stockModel).Entity;

            _context.Stocks.Add(stock);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStock), new { id = stock.Id }, stock.toStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStock([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.Id==id);
            if (stock == null)
            {
                return NotFound();
            }
            stock.Symbol = updateDto.Symbol;
            stock.CompanyName = updateDto.CompanyName;
            stock.Purchase = updateDto.Purchase;
            stock.Dividend = updateDto.Dividend;
            stock.Industry = updateDto.Industry;
            stock.MarketCap = updateDto.MarketCap;
            _context.SaveChanges();
            return Ok(stock.toStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStock([FromRoute] int id)
        {
            var stock = _context.Stocks.FirstOrDefault(x=> x.Id ==id);
            if (stock == null)
            {
                return NotFound();
            }
            _context.Stocks.Remove(stock);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
