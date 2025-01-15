using Microsoft.EntityFrameworkCore;
using Stock_Market_WebAPI.Data;
using Stock_Market_WebAPI.Dtos.Stock;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> AddStock(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteStock(int id)
        {
          var stockModel = _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.RemoveRange();
            await _context.SaveChangesAsync();
            return await stockModel;
        }


        
        public async Task<Stock?> GetStock(int id)
        {
            return await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _context.Stocks.Include(c=> c.Comments).ToListAsync();
        }

        public Task<bool> StockExist(int id)
        {
            return _context.Stocks.AnyAsync(x => x.Id == id);

        }

        public async Task<Stock?> UpdateStock(int id, UpdateStockRequestDto updateModel)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stock == null)
            {
                return null;
            }
            stock.Symbol = updateModel.Symbol;
            stock.CompanyName = updateModel.CompanyName;
            stock.Purchase = updateModel.Purchase;
            stock.Dividend = updateModel.Dividend;
            stock.Industry = updateModel.Industry;
            stock.MarketCap = updateModel.MarketCap;

            await _context.SaveChangesAsync();

            return stock;
        }
    }
}
