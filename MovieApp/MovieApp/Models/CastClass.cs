using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class CastClass
    {
        public int id { get; set; }
        public IList<Cast> cast { get; set; }



        //CONSTANTES
        private string api_key = "/credits?api_key=a53f89eb22343648161f97add0de0bbf";
        private string movieUri = "https://api.themoviedb.org/3/movie/";

        private string imageUrl = "http://image.tmdb.org/t/p/w92/";


        //METODOS
        public async Task<IList<Cast>> GetCredits(string id)
        {
            IList<Cast> data = new List<Cast>();
            CastClass resp = new CastClass();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(string.Concat(movieUri, id, api_key));
                var json = await response.Content.ReadAsStringAsync();
                resp = JsonConvert.DeserializeObject<CastClass>(json);
                var x = resp;
            }
            if (resp.cast.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    resp.cast[i].profile_path = string.Concat(imageUrl, resp.cast[i].profile_path);
                    data.Add(resp.cast[i]);
                }
            }
            else
            {
                for (int i = 0; i < resp.cast.Count; i++)
                {
                    resp.cast[i].profile_path = string.Concat(imageUrl, resp.cast[i].profile_path);
                    data.Add(resp.cast[i]);
                }
            }


            return data;
        }

    }
}
