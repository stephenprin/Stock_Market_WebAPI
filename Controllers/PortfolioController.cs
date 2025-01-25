using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stock_Market_WebAPI.Interfaces;
using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController
    {
        public PortfolioController(UserManager<AddUser> userManager, IStockRepository stockRepository)
        {
            
        }
    }
}
