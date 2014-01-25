using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Trosi.Configuration;
using Trosi.Exceptions;

namespace Trosi
{
    public class Translator
    {
        private const string _authenticationServiceUrl = @"https://datamarket.accesscontrol.windows.net/v2/OAuth2-13";
        private const string _translatorApiUrlFormat = @"http://api.microsofttranslator.com/v2/Http.svc/Translate?text={0}&from={1}&to={2}";

        private bool _isAuthenticated = false;
        private DateTime _sessionEndTime = DateTime.MinValue;
        private string _currentAccessToken;

        public string Translate(string text, string from, string to)
        {        
            using (var client = new HttpClient())
            {
                var url = string.Format(
                        _translatorApiUrlFormat,
                        HttpUtility.UrlEncode(text),
                        HttpUtility.UrlEncode(from),
                        HttpUtility.UrlEncode(to));

                using (var message = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", GetAccessToken());

                    using (var result = client.SendAsync(message).Result)
                    {
                        if (!result.IsSuccessStatusCode)
                        {
                            throw new TrosiTranslationException(result.Content.ReadAsStringAsync().Result);
                        }

                        using (var responseStream = result.Content.ReadAsStreamAsync().Result)
                        {
                            var serializer = new DataContractSerializer(typeof(string));

                            return serializer.ReadObject(responseStream) as string;
                        }
                    }
                }
            }
        }

        private string GetAccessToken()
        {
            if (_isAuthenticated && _sessionEndTime > DateTime.UtcNow)
            {
                return _currentAccessToken;
            }

            using (var client = new HttpClient())
            {
                using (var message = new HttpRequestMessage(HttpMethod.Post, _authenticationServiceUrl))
                {
                    var body = string.Format(@"grant_type=client_credentials&client_id={0}&client_secret={1}&scope=http://api.microsofttranslator.com",
                            HttpUtility.UrlEncode(TrosiConfiguration.ClientId),
                            HttpUtility.UrlEncode(TrosiConfiguration.ClientSecret));

                    message.Content = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");

                    using (var result = client.SendAsync(message).Result)
                    {
                        if (!result.IsSuccessStatusCode)
                        {
                            throw new TrosiAuthenticationException(result.Content.ReadAsStringAsync().Result);
                        }

                        using (var responseStream = result.Content.ReadAsStreamAsync().Result)
                        {
                            var serializer = new DataContractJsonSerializer(typeof(AuthenticationToken));

                            var token = serializer.ReadObject(responseStream) as AuthenticationToken;

                            _currentAccessToken = token.access_token;
                            _sessionEndTime = DateTime.UtcNow.AddSeconds(token.expires_in).AddMinutes(-1);
                            _isAuthenticated = true;

                            return _currentAccessToken;
                        }
                    }
                }
            }
        }
    }
}
