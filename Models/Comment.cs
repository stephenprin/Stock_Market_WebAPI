﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_Market_WebAPI.Models
{
    [Table("Comment")]
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }= string.Empty;
        public string Content { get; set; } = string.Empty; 
        public DateTime CreatedOn { get; set; }= DateTime.Now;

        public Guid? StockId { get; set; }
   
        public Stock? Stock { get; set; }
    }
}
