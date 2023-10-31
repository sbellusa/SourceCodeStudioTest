using SourceCodeStudioTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using SourceCodeStudioTest.Http;

namespace SourceCodeStudioTest.Services
{
    public class DogService : IDogService
    {
        static readonly string BaseUrl = "https://dog.ceo/api/";
        static readonly string RandomDogPath= "breeds/image/random";

        HttpClient _httpClient;
        IHttpClientFactory _httpClientFactory;

        public DogService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();

            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        /// <summary>
        /// Retrieves a random dog image
        /// </summary>
        /// <returns>A DogResponse class containing a random dog image</returns>
        public async Task<DogResponse> GetRandomDogAsync()
        {
            var request = new RequestBase<DogResponse>(RequestMethods.Get, RandomDogPath);

            var response = await _httpClient.ProcessAsync(request);

            return response;
        }
    }
}
