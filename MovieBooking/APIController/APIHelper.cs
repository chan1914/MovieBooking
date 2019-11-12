using MovieBooking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieBooking.APIController
{
	public class APIHelper
	{
		public string APIGetAllMovies { get; set; } = "http://simonsmoviebooking.azurewebsites.net/api/movie";
		public string APIGetMovieById { get; set; } = "http://simonsmoviebooking.azurewebsites.net/api/movie/1";
		public string APIPutBookMovieById { get; set; } = "http://simonsmoviebooking.azurewebsites.net/api/movie/BookMovie/1";
		public string APIPostNewMovie { get; set; } = "http://simonsmoviebooking.azurewebsites.net/api/movie";
		public string APIDeleteMovieById { get; set; } = "http://simonsmoviebooking.azurewebsites.net/api/movie/1";


		public List<Movie> GetJsonData()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIGetAllMovies);
			request.Method = "GET";

			string json;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse(); 
			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				json = reader.ReadToEnd();
			}
			List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(json);
			return movies;
		}
	}
}
