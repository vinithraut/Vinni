using VinniDatingApp.Entities;

namespace VinniDatingApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
       
    }
}
