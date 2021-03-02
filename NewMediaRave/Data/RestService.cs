﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewMediaRave.Models;
using Newtonsoft.Json;
using System.Text;
using static SQLite.SQLite3; //added here to fix an error. --K
/*
 Note: Most of our code comes from a tutorial put together by YouTube creator, Bert Bosch. --K

Citation: APA format 
Bosch, B. (Creator). (2017, December 31). Xamarin tutorials [Video playlist]. Retrieved February 26, 2021, from
https://www.youtube.com/playlist?list=PLV916idiqLvcKS1JY3S3jHWx9ELGJ1cJB

 */

namespace NewMediaRave.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 250000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));

        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.username));
            postData.Add(new KeyValuePair<string, string>("password", user.password));
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.LoginUrl, content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expire_in);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            Token token = App.TokenDatabase.GetToken();

            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.access_token);
            try
            {
                var result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonResult = result.Content.ReadAsStringAsync().Result;
                    try {
                        var ContentResp = JsonConvert.DeserializeObject<T>(jsonResult);
                        return ContentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }

            }
            catch
            {
                return null;
            }
            return null; 

        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            var response = await client.GetAsync(weburl);
            var JsonResult = response.Content.ReadAsStringAsync().Result;
            var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
            return ContentResp;
           
        }
    }
}
