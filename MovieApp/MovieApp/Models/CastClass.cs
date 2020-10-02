using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MovieApp.Models
{
    public class CastClass
    {
        public int? id { get; set; }
        public IList<Cast> Cast { get; set; }



        //CONSTANTES
        private string api_key = "/credits?api_key=a53f89eb22343648161f97add0de0bbf";
        private string movieUri = "https://api.themoviedb.org/3/movie/";

        private string imageUrl = "https://image.tmdb.org/t/p/w92/";
        private HttpClient httpClient;


        //METODOS
        public async Task<IList<Cast>> GetCredits(string id)
        {
            IList<Cast> data = new List<Cast>();
            CastClass resp = new CastClass();
            string uri = String.Concat(movieUri, id, api_key);

            httpClient = new HttpClient();



            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    this.httpClient = new HttpClient(DependencyService.Get<Services.IHTTPClientHandlerCreationService>().GetInsecureHandler());
                    break;
                default:
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    this.httpClient = new HttpClient(new HttpClientHandler());
                    break;
            }


            var response = await httpClient.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            resp = JsonConvert.DeserializeObject<CastClass>(json);
            var x = resp;


            //using (HttpClient httpClient = new HttpClient())
            //{
            //    var response = await httpClient.GetAsync(uri);
            //    var json = await response.Content.ReadAsStringAsync();
            //    resp = JsonConvert.DeserializeObject<CastClass>(json);
            //    var x = resp;
            //}
            if (resp.Cast.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    resp.Cast[i].profile_path = string.Concat(imageUrl, resp.Cast[i].profile_path);
                    data.Add(resp.Cast[i]);
                }
            }
            else
            {
                for (int i = 0; i < resp.Cast.Count; i++)
                {
                    resp.Cast[i].profile_path = string.Concat(imageUrl, resp.Cast[i].profile_path);
                    data.Add(resp.Cast[i]);
                }
            }
            return data;
        }

    }
}
