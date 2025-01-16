using Stock_Market_WebAPI.Dtos.Stock;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocks();
        Task<Stock?> GetStock(Guid id);
        Task<Stock> AddStock(Stock stockModel);
        Task<Stock?> UpdateStock(Guid id, UpdateStockRequestDto updateModel);
        Task<Stock?> DeleteStock(Guid id);
        Task<bool> StockExist(Guid id);
    }
}
