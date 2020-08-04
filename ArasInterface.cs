using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace BOM_Importer
{
    //
    //https://community.aras.com/b/english/posts/tech-tip-using-the-aras-restful-api
    //
    // examples:
    // https://github.com/ArasLabs/rest-auth-example
    //https://community.aras.com/i/projects/innovator-client-example

   public static class ArasInterface

    {

        const string innovatorUrl = "http://pdm-test.elcon-system.de/Innovator12/"; // base Innovator url
        const string innovatorUsername = "admin"; // Innovator user name 
        const string innovatorPassword = "607920b64fe136f9ab2389e371852af2"; // MD5 hash of Innovator user password (mush be SHA hash in case of FIPS)
        const string innovatorDatabase = "InnovatorSolutions12"; // database name, could be obtained from innovatorServerUrl+"dblist.aspx"
        const string oauthServerClientId = "IOMApp1"; // must be registered in authorization server's oauth.config file

        const string innovatorServerDiscoveryUrl = innovatorUrl + "Server/OAuthServerDiscovery.aspx";

        public static string get_token()
        {
            string oauthServerUrl = GetOAuthServerUrl(innovatorServerDiscoveryUrl);

            if (oauthServerUrl == null)
                Environment.Exit(0);


            //
            // Get token endpoint
            // ==================
            var oauthServerConfigurationUrl = oauthServerUrl + ".well-known/openid-configuration";

            var tokenUrl = GetTokenEndpoint(oauthServerConfigurationUrl);

            if (tokenUrl == null)
                Environment.Exit(0);


            // Get access token
            // ================
            var body = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("scope", "Innovator"),
                new KeyValuePair<string, string>("client_id", oauthServerClientId),
                new KeyValuePair<string, string>("username", innovatorUsername),
                new KeyValuePair<string, string>("password", innovatorPassword),
                new KeyValuePair<string, string>("database", innovatorDatabase),
            });

            var tokenData = GetJson(tokenUrl, null, body);

            if (tokenData == null)
                Environment.Exit(0);


            //
            // Request parts using OData
            // =========================
            var result = JObject.Parse(tokenData);
            string access_token = (string)result["access_token"];

            return access_token;
        }


        public static HttpClient RequestRead()
        {
            string oauthServerUrl = GetOAuthServerUrl(innovatorServerDiscoveryUrl);

            if (oauthServerUrl == null)
                Environment.Exit(0);

            
            //
            // Get token endpoint
            // ==================
            var oauthServerConfigurationUrl = oauthServerUrl + ".well-known/openid-configuration";

            var tokenUrl = GetTokenEndpoint(oauthServerConfigurationUrl);

            if (tokenUrl == null)
                Environment.Exit(0);

            
            // Get access token
            // ================
            var body = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("scope", "Innovator"),
                new KeyValuePair<string, string>("client_id", oauthServerClientId),
                new KeyValuePair<string, string>("username", innovatorUsername),
                new KeyValuePair<string, string>("password", innovatorPassword),
                new KeyValuePair<string, string>("database", innovatorDatabase),
            });

            var tokenData = GetJson(tokenUrl, null, body);

            if (tokenData == null)
                Environment.Exit(0);


            //
            // Request parts using OData
            // =========================
            var result = JObject.Parse(tokenData);
            string access_token = (string)result["access_token"];
            
            string odataUrl = innovatorUrl + "/server/odata/Manufacturer";
           
            var parts = GetJson(odataUrl, access_token);


            HttpClientHandler handler = new HttpClientHandler();

            using (var client = new HttpClient(handler, false))
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (access_token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                }

               

                return client;
            }


               

           
        }

        public static HttpResponseMessage Request_result(string url, string request,string accessToken = null, HttpContent body = null)
        {
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (accessToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }

                HttpResponseMessage response = null;
                if (request == "GET")
                {
                    response = client.GetAsync(url).Result;
                }
                else if(request == "POST")
                {
                    response = client.PostAsync(url, body).Result;
                   
                }
                else if(request == "PATCH")
                {
                    response =  PatchAsync(client, url, body).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    return response;
                }

            }

        }


        public static dynamic GetJson(string url, string accessToken = null, HttpContent body = null)
        {
            using (HttpClient client = new HttpClient())
            {
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (accessToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }

                HttpResponseMessage response;
                if (body == null)
                {
                    response = client.GetAsync(url).Result;
                }
                else
                {
                    response = client.PostAsync(url, body).Result;
                }

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return response.RequestMessage.Content.ReadAsStringAsync().Result;
                }

            }

        }

        public static string GetManufacturer_id(string manufacturer, string response)
        {
            var result = JObject.Parse(response);
            var rt = (JArray)result["value"];
            string manufacturer_id = string.Empty;


            foreach (var value in rt)
            {
                string list_manufacturer_id = (string)value["id"];
                string list_manufacturer = (string)value["name"];
                if(manufacturer == list_manufacturer)
                {
                    manufacturer_id = list_manufacturer_id;
                    break;

                }

            }

            return manufacturer_id;
        }

        public static string GetOAuthServerUrl(string url)
        {
            var discovery = GetJson(url);
            var result = JObject.Parse(discovery);
            var values = (JArray)result["locations"];
            string uri = string.Empty;

            foreach (var value in values)
            {
                uri = (string)value["uri"];

            }

            return uri;
        }

        public static string GetTokenEndpoint(string url)
        {
            var configuration = GetJson(url);
            var result = JObject.Parse(configuration);
            var token_endpoint = (string)result["token_endpoint"];

            return token_endpoint;
        }


        public static string Transaction_Id()
        {
            string id = string.Empty;
            string password = "y=ENtk%x";

            string URL = "http://pdm-test.elcon-system.de/Innovator12/" + "vault/odata/vault.BeginTransaction";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            string auth_password = MD5Hash(password);
            client.DefaultRequestHeaders.Add("AUTHPASSWORD",auth_password);

            string _ContentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            client.DefaultRequestHeaders.Add("DATABASE", "InnovatorSolutions12");
            client.DefaultRequestHeaders.Add("AUTHUSER", "teo");

            HttpResponseMessage response = client.PostAsync(URL, null).Result;
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = content.ReadAsStringAsync().Result;

                var jsonObj = JObject.Parse(result);
             
                id = (string)jsonObj["transactionId"];

                return id;
            }
            
        }



        public static string GetMD5Hash(string input)
        {

            //MD5Hash - calculation does not work well
            //var data = System.Text.Encoding.ASCII.GetBytes(input);
            //data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            //return Convert.ToBase64String(data);


            //!!!!!!!!!!!!!!!!!!!!!!!!!!
            // need rework!!!

            // MD5 md5 = new MD5CryptoServiceProvider();
            // byte[] textToHash = Encoding.Default.GetBytes(input);
            // byte[] result = md5.ComputeHash(textToHash);


            //Console.WriteLine("###" + System.BitConverter.ToString(result));


            // return System.BitConverter.ToString(result);

            return MD5Hash(input);
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();


        }

        public static HttpContent test_post(object req)
        {
            var encodedContent = JsonConvert.SerializeObject(req);
            HttpContent stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

            return stringContent;
        }

        public static HttpResponseMessage Manufacturer_POST_response(object req)
        {

            string urlParameters = "server/odata/Manufacturer";
            string req_url = innovatorUrl + urlParameters;
            string token = ArasInterface.get_token();

            var encodedContent = JsonConvert.SerializeObject(req);
            HttpContent stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");
           
            // POST request is executed
            HttpResponseMessage response_status = ArasInterface.Request_result(req_url,"POST", token, stringContent);
           // HttpResponseMessage response = client.PostAsync(urlParameters, stringContent).Result;

            return response_status;
    
        }

        public static string Manufacturer_GET_response(Object req)
        {
            string url = "http://pdm-test.elcon-system.de/Innovator12/server/odata/Manufacturer";
            string token = ArasInterface.get_token();

            string response_msg = ArasInterface.GetJson(url, token);

            return response_msg;

        }

        public static HttpResponseMessage Manufacturer_Part_POST_response(HttpContent Manufacturer_Part_JSON)
        {
            string url = "http://pdm-test.elcon-system.de/Innovator12/server/odata/Manufacturer Part";
            string token = ArasInterface.get_token();

            HttpResponseMessage response_msg = ArasInterface.Request_result(url,"POST",token, Manufacturer_Part_JSON);

            return response_msg;

        }

        public static bool  Manufacturer_status(object req)
        {
            string urlParameters = innovatorUrl + "server/odata/Manufacturer";
            string token = ArasInterface.get_token();
            bool check = false;

            HttpResponseMessage response = ArasInterface.Request_result(urlParameters, "GET", token);

            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = content.ReadAsStringAsync().Result;

                var jsonObj = JObject.Parse(result);
                var values = (JArray)jsonObj["value"];

                foreach (var value in values)
                {
                    string id = (string)value["id"];


                    string edit_url_manufacturer = innovatorUrl + "server/odata/Manufacturer('" + id + "')";
                    string token_req = ArasInterface.get_token();
                    HttpResponseMessage response_result = ArasInterface.Request_result(edit_url_manufacturer, "GET", token_req);

                    if (response_result.IsSuccessStatusCode)
                    {
                        check = true;
                        continue;
                    }
                    else
                    {
                       // File.AppendAllText(path, "<Item type=\"Manufacturer\" action=\"add\"> \n <name>" + req + "</name> \n </Item> \n" + Environment.NewLine);
                       // new_items++;
                    }
                }
            }

            return check;



              
        }

        public static bool Manufacturer_Edit_response(object req)
        {
           
            string urlParameters = innovatorUrl + "server/odata/Manufacturer";
            string token = ArasInterface.get_token();

            var encodedContent = JsonConvert.SerializeObject(req);
            HttpContent stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = ArasInterface.Request_result(urlParameters,"PATCH",token, stringContent);
            if (response.IsSuccessStatusCode)
            {

                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    string result = content.ReadAsStringAsync().Result;

                    var jsonObj = JObject.Parse(result);
                    var values = (JArray)jsonObj["value"];

                    foreach (var value in values)
                    {
                        string id = (string)value["id"];


                        string edit_url_manufacturer = innovatorUrl + "server/odata/Manufacturer('" + id + "')";

                       
                       
                        HttpResponseMessage edit_response = ArasInterface.Request_result(edit_url_manufacturer,"PATCH",token, stringContent);


                        if (edit_response.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        internal static bool Manufacturer_Part_GET_response(string item_number)
        {
            string url = "http://pdm-test.elcon-system.de/Innovator12/server/odata/Manufacturer Part?$filter=item_number eq '" + item_number  + "'";
            string token = ArasInterface.get_token();
            bool check = false;

            string determine_value = ArasInterface.GetJson(url, token);

            var jsonObj = JObject.Parse(determine_value);
            var values = (JArray)jsonObj["value"];

            JToken req_value = values.First;

            if(req_value == null)
            {
                check = true;
            }

            return check;

        }

        public  static Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(client.BaseAddress + requestUri),
                Content = content,
            };

            return client.SendAsync(request);
        }


        public static bool Part_response(string part_number)
        {
          
            HttpClient client = ArasInterface.RequestRead();
            string urlParameters = innovatorUrl + "server/odata/Part?$filter=item_number eq '"+part_number+"'";
            string token = get_token();

            //var encodedContent = JsonConvert.SerializeObject(req);
            //var stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = ArasInterface.Request_result(urlParameters,"GET",token);
            
          
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static bool Part_Edit_response(string part_number, Dictionary<string,string> req)
        {
            HttpClient client = ArasInterface.RequestRead();
            string urlParameters = "server/odata/Part?$filter=item_number eq '" + part_number + "'";
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            HttpResponseMessage edit_response = null;
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    string result = content.ReadAsStringAsync().Result;

                    var jsonObj = JObject.Parse(result);
                    var values = (JArray)jsonObj["value"];

                foreach (var value in values)
                {
                    string id = (string)value["id"];


                    string edit_url_manufacturer = "server/odata/Part('" + id + "')";

                    var encodedContent = JsonConvert.SerializeObject(req);
                    var stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");


                  edit_response = ArasInterface.PatchAsync(client, edit_url_manufacturer, stringContent).Result;


                    
                }

                }


            if (edit_response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool Part_POST_response(object req, string part_number)
        {
          
                HttpClient client = ArasInterface.RequestRead();
                string urlParameters = innovatorUrl + "server/odata/Part?$filter=item_number eq '" + part_number + "'";
                string token = get_token();

                var encodedContent = JsonConvert.SerializeObject(req);
                var stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = ArasInterface.Request_result(urlParameters,"POST", token, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
     
        }

        public static bool Device_response(string part_number)
        {
            HttpClient client = ArasInterface.RequestRead();
            string urlParameters = innovatorUrl + "server/odata/Part?$filter=item_number eq '" + part_number + "'";
            string token = get_token();

            //var encodedContent = JsonConvert.SerializeObject(req);
            //var stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = ArasInterface.Request_result(urlParameters, "GET", token);


            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool Device_POST_response(object device_unique, string part_number)
        {

            HttpClient client = ArasInterface.RequestRead();
            string urlParameters = innovatorUrl + "server/odata/Part?$filter=item_number eq '" + part_number + "'";
            string token = get_token();

            var encodedContent = JsonConvert.SerializeObject(device_unique);
            var stringContent = new StringContent(encodedContent, UnicodeEncoding.UTF8, "application/json");

            HttpResponseMessage response = ArasInterface.Request_result(urlParameters, "POST", token, stringContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }





    }
}
