using System.ComponentModel.DataAnnotations;

namespace Stock_Market_WebAPI.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannnot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Company name cannnot be over 100 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal Dividend { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Industry name cannot be over 50 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000000000000)]
        public long MarketCap { get; set; }
    }
}
