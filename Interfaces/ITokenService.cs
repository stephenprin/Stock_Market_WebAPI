using Stock_Market_WebAPI.Models;

namespace Stock_Market_WebAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AddUser addUser);
    }
}
