using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of MovieController.
	/// </summary>
	public class MovieController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();
		
	    [HttpPost]
		[Route("api/movie")]		
        public IHttpActionResult Create(Movie movie)
        {
        	_db.Movies.Add(movie);
            _db.SaveChanges();
            return Ok(movie);
        }
        
     	[HttpGet]
		[Route("api/movie")]		
        public IHttpActionResult GetAll(string keyword = "")
        {
           keyword = keyword.Trim();
           var movies =  _db.Movies
           	.Where(x => 
           	       x.Actor.ToLower().Contains(keyword) || 
           	       x.Title.ToLower() .Contains(keyword) || 
         	       x.Writer.ToLower() .Contains(keyword))
           	.ToList();
       		return Ok(movies);
        }
        
        [HttpGet]
    	[Route("api/movie/{Id}")]		
        public IHttpActionResult Get(int Id)
        {       
            var movie = _db.Movies.Find(Id);
            if (movie != null)
                return Ok(movie);
            else
                return BadRequest("movie Id is invalid or not found");

        }
       [HttpDelete]
        [Route("api/movie/{Id}")]		
        public IHttpActionResult Delete(int Id)
        {
            var movie = _db.Movies.Find(Id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
                return Ok("Movie removed successfully!");
            }
            else
                return BadRequest("Movie Id does not exist");

        }
         [HttpPut]
        [Route("api/movie")]		
        public IHttpActionResult Update(Movie updateMovie)
        {
            var movie = _db.Movies.Find(updateMovie.Id);
            if (movie != null)
            {	
            	movie.Title = updateMovie.Title;
            	movie.Actor = updateMovie.Actor;
        		movie.Director = updateMovie.Director;
        		movie.Poster = updateMovie.Poster;
        		movie.Genre = updateMovie.Genre;
        		
        		
        		movie.Language = updateMovie.Language;
        		movie.Summary = updateMovie.Summary;
        		movie.Release = updateMovie.Release;
        		movie.Runtime = updateMovie.Runtime;
        		movie.Writer = updateMovie.Writer;
   
        		movie.Type = updateMovie.Type;
        		movie.Ratings = updateMovie.Ratings;
        		movie.Release = updateMovie.Release;
        		
                _db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(movie);
            }
            else
                return BadRequest("Diary id is invalid or not found");
        }
	}
}