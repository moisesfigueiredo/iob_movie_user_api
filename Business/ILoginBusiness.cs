﻿using IobMovieUserAPI.Domain.ValueObjects;

namespace IobMovieUserAPI.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);
    }
}
