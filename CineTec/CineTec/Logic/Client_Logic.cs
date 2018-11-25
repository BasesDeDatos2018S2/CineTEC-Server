using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace CineTec.Logic
{
    public class Client_Logic
    {
        public Object GetClients()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ec2-18-188-33-240.us-east-2.compute.amazonaws.com:8080/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            HttpResponseMessage response = client.GetAsync("api/Client").Result;  // Blocking call!    
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<Object>().Result;
                return products;
            }
            else
            {
                return null;
            }
        }

        public Object GetClient(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://ec2-18-188-33-240.us-east-2.compute.amazonaws.com:8080/");
            // Add an Accept header for JSON format.    
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.    
            HttpResponseMessage response = client.GetAsync("api/Client/"+id).Result;  // Blocking call!    
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<Object>().Result;
                return products;
            }
            else
            {
                return null;
            }
        }
        
    }
}