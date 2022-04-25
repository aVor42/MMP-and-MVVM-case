using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;

namespace MvvmClient.Services
{
    public static class HttpRequestService
    {
        public static string Get(string url, string authToken, Dictionary<string, string> data = null)
        {
            if(data != null)
                url += "?" + ToUrlParams(data);

            var request = (HttpWebRequest)WebRequest.Create(url);
            if (authToken != null)
                request.Headers.Add(HttpRequestHeader.Authorization, authToken);

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string Post(string url, string authToken, Dictionary<string, string> data)
        {

            try
            {
                var client = new HttpClient();
                if (authToken != null)
                    client.DefaultRequestHeaders.Add("Authorization", authToken);
                
                var content = new FormUrlEncodedContent(data);
                var response = client.PostAsync(url, content).Result;

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException)
            {
                return "Ошибка";
            }

        }

        public static string Put(string url, string authToken, Dictionary<string, string> data)
        {

            try
            {
                var client = new HttpClient();
                if (authToken != null)
                    client.DefaultRequestHeaders.Add("Authorization", authToken);

                url += "?" + ToUrlParams(data);

                var content = new FormUrlEncodedContent(data);
                var response = client.PutAsync(url, content).Result;

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException)
            {
                return "Ошибка";
            }

        }

        public static string Delete(string url, string authToken, Dictionary<string, string> data)
        {

            try
            {
                var client = new HttpClient();
                if (authToken != null)
                    client.DefaultRequestHeaders.Add("Authorization", authToken);

                url += "?" + ToUrlParams(data);
                var response = client.DeleteAsync(url).Result;

                response.EnsureSuccessStatusCode();

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException)
            {
                return "Ошибка";
            }

        }

        public static string AuthOrRegister(string url, Dictionary<string, string> data)
        {
            var client = new HttpClient();

            var content = new FormUrlEncodedContent(data);
            var response = client.PostAsync(url, content).Result;

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Content.ReadAsStringAsync().Result);

            return string.Join("", response.Headers.GetValues("Authorization"));
        }

        public static void Logout(string url, string authToken)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", authToken);

                var response = client.PostAsync(url, new FormUrlEncodedContent(new Dictionary<string, string>())).Result;

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException)
            {
                throw new Exception("Ошибка выхода");
            }
        }

        private static string ToUrlParams(Dictionary<string, string> data)
        {
            return string.Join("&", data.Select(p => $"{p.Key}={p.Value}"));
        }


    }
}
