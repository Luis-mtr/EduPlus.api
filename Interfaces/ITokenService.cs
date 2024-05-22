using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, IList<string> roles);
    }
}