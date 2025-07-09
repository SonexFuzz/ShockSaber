using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ShockSaber.config;

namespace ShockSaber.API
{
    public class PiShockAPI
    {
        private readonly PluginConfig _config;
        private string apiEndpoint = "https://do.pishock.com/api/apioperate/";


        public PiShockAPI(PluginConfig config)
        {
            _config = config;
        }
        
        
        public async Task Shock(int intensity, int duration)
        {
            using (HttpClient client = new HttpClient())
            {
                // Request data
                var requestData = new
                {
                    Username = _config.username,
                    Name = _config.senderName,
                    Code = _config.Code,
                    Intensity = intensity,
                    Duration = duration,
                    Apikey = _config.apiKey,
                    Op = 0
                };

                // Serialize the request data to JSON
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

                // Create StringContent with the correct content type
                using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Plugin.Log.Info("Request sent successfully.");

                    }
                    else
                    {
                        Plugin.Log.Info($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                        string responseContent = await response.Content.ReadAsStringAsync();
                        Plugin.Log.Info($"Response Content: {responseContent}");
                    }
                }
            }
        }

        public async Task Vibrate(int intensity, int duration)
        {
            using (HttpClient client = new HttpClient())
            {
                // Request data
                var requestData = new
                {
                    Username = _config.username,
                    Name = _config.senderName,
                    Code = _config.Code,
                    Intensity = intensity,
                    Duration = duration,
                    Apikey = _config.apiKey,
                    Op = 1
                };

                // Serialize the request data to JSON
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

                // Create StringContent with the correct content type
                using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Plugin.Log.Info("Request sent successfully.");
                    }
                    else
                    {
                        Plugin.Log.Info($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                        // Print the response content for further debugging
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Plugin.Log.Info($"Response Content: {responseContent}");
                    }
                }
            }
        }

        public async Task Beep(int duration)
        {
            using (HttpClient client = new HttpClient())
            {
                // Request data
                var requestData = new
                {
                    Username = _config.username,
                    Name = _config.senderName,
                    Code = _config.Code,
                    Duration = duration,
                    Apikey = _config.apiKey,
                    Op = 2
                };

                // Serialize the request data to JSON
                string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

                // Create StringContent with the correct content type
                using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
                {
                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiEndpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        Plugin.Log.Info("Request sent successfully");
                    }
                    else
                    {
                        Plugin.Log.Info($"Error: {response.StatusCode} - {response.ReasonPhrase}");

                        string responseContent = await response.Content.ReadAsStringAsync();
                        Plugin.Log.Info($"Response Content: {responseContent}");
                    }
                }
            }
        }

    }
}