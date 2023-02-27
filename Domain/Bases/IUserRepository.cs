using Domain.Entitites;
using IobMovieUserAPI.Domain.ValueObjects;

namespace Infra.Bases
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}
