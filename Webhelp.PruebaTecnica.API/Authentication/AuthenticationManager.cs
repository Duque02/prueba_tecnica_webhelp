using System;
namespace Webhelp.PruebaTecnica.API.Authentication
{
	public class AuthenticationManager : IAuthenticationManager
    {
		public readonly IConfiguration _configuration;

		public AuthenticationManager(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void validateApiKey(string? apiKey)
		{
			if(string.IsNullOrEmpty(apiKey))
			{
				throw new AuthenticationException();
			}

			string? storedApiKey = _configuration.GetValue<string>("ApiKey");

            if (string.IsNullOrEmpty(storedApiKey))
            {
                throw new AuthenticationException();
            }

			if (apiKey != storedApiKey)
			{
                throw new AuthenticationException();
            }
        }
	}
}

