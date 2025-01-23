using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Stock_Market_WebAPI.Models
{
    [Table("User")]
    public class AddUser: IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; }= new List<Portfolio>();
    }
}
