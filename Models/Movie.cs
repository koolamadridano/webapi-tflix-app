
using System;

namespace SharpDevelopWebApi.Models
{

	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Poster { get; set; }
		public string Summary { get; set; }
		public string Runtime { get; set; }
		public string Director { get; set; }
		public string Type { get; set; }
		public string Writer { get; set; }
		public string Actor { get; set; }
		public string Release { get; set; }
		public string Genre { get; set; }
		public string Ratings { get; set; }
		public string Rated { get; set; }
		public string Language { get; set; }
	}
}
