using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieApp.Models
{
    public class Root
    {

        //ATRIBUTOS
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Result> results { get; set; }
        public Dates dates { get; set; }


        //CONSTANTES
        private string api_key = "a53f89eb22343648161f97add0de0bbf";
        private string topRateUri = "https://api.themoviedb.org/3/movie/top_rated?api_key=";
        private string upconmingUri = "https://api.themoviedb.org/3/movie/upcoming?api_key=";
        private string popularUri = "https://api.themoviedb.org/3/movie/popular?api_key=";
        private string endUri = "&language=en-US&page=1";
        private string imageUrl = "http://image.tmdb.org/t/p/w500/";




        //METODOS
        public async Task<List<Result>> GetTopRate()
        {
            Root resp;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(string.Concat(topRateUri, api_key, endUri));
                var json = await response.Content.ReadAsStringAsync();
                resp = JsonConvert.DeserializeObject<Root>(json);
            }
            return filterMethod(resp);
        }

        public async Task<List<Result>> GetUpconming()
        {
            Root resp;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(string.Concat(upconmingUri, api_key, endUri));
                var json = await response.Content.ReadAsStringAsync();
                resp = JsonConvert.DeserializeObject<Root>(json);
            }
            return filterMethod(resp);
        }

        public async Task<List<Result>> GetPopular()
        {
            Root resp;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(string.Concat(popularUri, api_key, endUri));
                var json = await response.Content.ReadAsStringAsync();
                resp = JsonConvert.DeserializeObject<Root>(json);
            }
            return filterMethod(resp);
        }


        private List<Result> filterMethod(Root data)
        {
            List<Result> result = new List<Result>();

            if (data.results.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    data.results[i].poster_path = string.Concat(imageUrl + data.results[i].poster_path);
                    data.results[i].backdrop_path = string.Concat(imageUrl + data.results[i].backdrop_path);
                    result.Add(data.results[i]);
                }
            }
            else
            {
                for (int i = 0; i <= data.results.Count; i++)
                {
                    data.results[i].poster_path = string.Concat(imageUrl + data.results[i].poster_path);
                    data.results[i].backdrop_path = string.Concat(imageUrl + data.results[i].backdrop_path);
                    result.Add(data.results[i]);
                }
            }
            return result;
        }

    }
}

