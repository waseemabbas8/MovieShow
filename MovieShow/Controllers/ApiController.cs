using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieShow.Models;
using MovieShow.Resources;
using Newtonsoft.Json;
using TMDBAPI.Models;

namespace MovieShow.Controllers
{
    public class ApiController : Controller
    {
        public static async Task<IList<Movie>> GetMoviesAsync(string RelativeURL)
        {
            IList<Movie> MovieIfo = new List<Movie>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(ApiInfo.BASE_URL);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(RelativeURL+ApiInfo.API_KEY);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    MovieIfo = JsonConvert.DeserializeObject<MovieResponse>(EmpResponse).Results;

                }
                //returning the employee list to view  
                return MovieIfo;
            }
        }
    }
}