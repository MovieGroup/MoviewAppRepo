using System;
using System.Net.Http;

namespace MovieApp.Services
{
    public interface IHTTPClientHandlerCreationService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
