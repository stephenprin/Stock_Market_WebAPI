using Stock_Market_WebAPI.Dtos.Stock;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocks();
        Task<Stock?> GetStock(int id);
        Task<Stock> AddStock(Stock stockModel);
        Task<Stock?> UpdateStock(int id, UpdateStockRequestDto updateModel);
        Task<Stock?> DeleteStock(int id);
    }
}
