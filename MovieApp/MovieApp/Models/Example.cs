using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace MovieApp.Models
{
    public class Example
    {
        public IList<Genre> genres { get; set; }
        [JsonIgnore]
        public string list_genres { get; set; }
        [JsonIgnore]
        public string list_companies { get; set; }
        public IList<ProductionCompany> production_companies { get; set; }
        public string release_date { get; set; }

        //CONSTANTES
        private string api_key = "?api_key=a53f89eb22343648161f97add0de0bbf";
        private string movieUri = "https://api.themoviedb.org/3/movie/";
        private string endUri = "&language=en-US";


        //METODOS
        public async Task<Example> GetDetail(string id)
        {
            Example resp = new Example();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(string.Concat(movieUri, id, api_key, endUri));
                    var json = await response.Content.ReadAsStringAsync();
                    resp = JsonConvert.DeserializeObject<Example>(json);
                }

                if (resp.production_companies != null && resp.production_companies.Any())
                {
                    resp.production_companies.ToList().ForEach(x => list_companies += string.Concat(x.name, ", "));
                    list_companies = list_companies.EndsWith(",") ? list_companies.TrimEnd(',') : list_companies;
                }


                if (resp.genres != null)
                {
                    resp.genres.ToList().ForEach(x => list_genres += string.Concat(x.name, ", "));
                    list_genres = list_genres.EndsWith(",") ? list_genres.TrimEnd(',') : list_genres;
                }

                resp.list_genres = list_genres;
                resp.list_companies = list_companies;
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                message = ex.Message;
            }

            return resp;
        }

    }


}
