using DomainBellaNS.API.ExternalService;
using System.Text.Json;
using System.Text;
using System.Reflection;
using NLog;

namespace ExternalService
{

    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class ExternalServiceImpl : DomainBellaNS.API.ExternalService.ExternalService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public async Task<List<ActiveBundle>> ExternalCall1(string url)
        {
            var client = new HttpClient { BaseAddress = new Uri(url.Replace("\\", "/")) };
            var response = await client.GetAsync("");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            return await response.Content.ReadFromJsonAsync<List<ActiveBundle>>();
        }

        public async Task<string> ExternalCall3(string url)
        {
            return url.Replace("\\", "/");
            //var client = new HttpClient { BaseAddress = new Uri(url.Replace("\\", "/")) };
            //var response = await client.GetAsync("");
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new Exception(await response.Content.ReadAsStringAsync());
            //}
            //return await response.Content.ReadFromJsonAsync<List<ActiveBundle>>();
        }
        public async Task<List<BundleWithPrice>> ExternalCall2(string url, List<int> body)
        {
            var client = new HttpClient { BaseAddress = new Uri(url.Replace("\\", "/")) };
            var contentString = JsonSerializer.Serialize(body);
            var content = new StringContent(contentString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            return await response.Content.ReadFromJsonAsync<List<BundleWithPrice>>();
        }


    }
}