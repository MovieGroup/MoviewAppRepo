using System;
using System.Collections.Generic;
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
        private string topRateUri = "https://api.themoviedb.org/3/movie/top_rated?";
        private string upconmingUri = "https://api.themoviedb.org/3/movie/upcoming";
        private string popularUri = "https://api.themoviedb.org/3/movie/popular";
        private string endUri = "&language=en-US&page=1";




        //METODOS
        public async Task<Root> GetTopRate()
        {
            Root root = new Root();
            return root;
        }

        public async Task<Root> GetUpcoming()
        {
            Root root = new Root();
            return root;
        }

        public async Task<Root> GetPopular()
        {
            Root root = new Root();
            return root;
        }

    }
}

