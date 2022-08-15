using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Services.Infrastructure
{
    public abstract class BaseClient
    {

        protected JsonWebToken CurrentToken { get; set; }
        protected string BaseUrl { get; set; }

        internal string GetToken()
        {
            if (CurrentToken == null || string.IsNullOrEmpty(CurrentToken.EncodedToken))
            {
                throw new Exception();
            }

            var token = CurrentToken.EncodedToken;

            return token;
        }

        internal BaseClient()
        {
        }
    }
}