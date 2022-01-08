using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace wellsfargo.comBot.Models
{
    public class HttpCaller
    {
        HttpClient _httpClient;

        readonly HttpClientHandler _httpClientHandler = new HttpClientHandler()
        {
            // CookieContainer = new CookieContainer(),
            UseCookies = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        public HttpCaller(bool userSession = false)
        {
            _httpClient = new HttpClient(_httpClientHandler);
            if (userSession)
            {
                var cookies = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("ses"));
                var sb = new StringBuilder();
                foreach (var cookie in cookies)
                {
                    sb.Append($"{cookie.Key}={cookie.Value};");
                }

                _httpClient.DefaultRequestHeaders.Add("Cookie", sb.ToString());
            }
        }

        public async Task<HtmlDocument> GetDoc(string url, int maxAttempts = 1)
        {
            var html = await GetHtml(url, maxAttempts);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }

        public async Task<string> GetHtml(string url, int maxAttempts = 1)
        {
            int tries = 0;
            do
            {
                try
                {
                    var response = await _httpClient.GetAsync(url);
                    string html = await response.Content.ReadAsStringAsync();
                    return html;
                }
                catch (WebException ex)
                {
                    var errorMessage = "";
                    try
                    {
                        errorMessage = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    }
                    catch (Exception)
                    {
                    }

                    tries++;
                    if (tries == maxAttempts)
                    {
                        throw new Exception(ex.Status + " " + ex.Message + " " + errorMessage);
                    }

                    await Task.Delay(2000);
                }
            } while (true);
        }

        public async Task<string> PostJson(string url, string json, int maxAttempts = 1)
        {
            int tries = 0;
            do
            {
                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // content.Headers.Add("x-appeagle-authentication", Token);
                    var r = await _httpClient.PostAsync(url, content);
                    var s = await r.Content.ReadAsStringAsync();
                    return (s);
                }
                catch (WebException ex)
                {
                    var errorMessage = "";
                    try
                    {
                        errorMessage = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    }
                    catch (Exception)
                    {
                    }

                    tries++;
                    if (tries == maxAttempts)
                    {
                        throw new Exception(ex.Status + " " + ex.Message + " " + errorMessage);
                    }

                    await Task.Delay(2000);
                }
            } while (true);
        }

        public async Task DownloadFile(string url, string localPath)
        {
            // var x = new HttpRequestMessage(HttpMethod.Post, url);
            // x.Headers.Add("Sec-Fetch-Dest", "document");
            // x.Content = new FormUrlEncodedContent(formData);
            var response = await _httpClient.GetAsync(url);
            using (var fs = new FileStream(localPath, FileMode.Create))
            {
                await response.Content.CopyToAsync(fs);
            }
        }

        public async Task DownloadFile(string url, string localPath, Dictionary<string, string> formData)
        {
            var x = new HttpRequestMessage(HttpMethod.Post, url);
            x.Headers.Add("Sec-Fetch-Dest", "document");
            x.Content = new FormUrlEncodedContent(formData);
            var response = await _httpClient.SendAsync(x);
            using (var fs = new FileStream(localPath, FileMode.Create))
            {
                await response.Content.CopyToAsync(fs);
            }
        }

        public async Task<string> PostFormData(string url, List<KeyValuePair<string, string>> formData, int maxAttempts = 1)
        {
            var formContent = new FormUrlEncodedContent(formData);
            int tries = 0;
            do
            {
                try
                {
                    var response = await _httpClient.PostAsync(url, formContent);
                    string html = await response.Content.ReadAsStringAsync();
                    return html;
                }
                catch (WebException ex)
                {
                    var errorMessage = "";
                    try
                    {
                        errorMessage = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    }
                    catch (Exception)
                    {
                    }

                    tries++;
                    if (tries == maxAttempts)
                    {
                        throw new Exception(ex.Status + " " + ex.Message + " " + errorMessage);
                    }

                    await Task.Delay(2000);
                }
            } while (true);
        }
    }
}