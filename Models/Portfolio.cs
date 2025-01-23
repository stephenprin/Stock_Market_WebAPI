using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_Market_WebAPI.Models
{
    [Table("Portfolio")]
    public class Portfolio
    {
        public string UserId { get; set; }
        public Guid StockId { get; set; }

        public AddUser AddUser { get; set; }
        public Stock Stock { get; set; }
    }
}
