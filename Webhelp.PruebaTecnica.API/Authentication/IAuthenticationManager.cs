using System;
namespace Webhelp.PruebaTecnica.API.Authentication
{
	public interface IAuthenticationManager
	{
        public void validateApiKey(string? apiKey);
    }
}

