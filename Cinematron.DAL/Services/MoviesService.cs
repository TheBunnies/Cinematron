using Cinematron.DAL.Contracts;
using Cinematron.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly CinematronDbContext _dbContext;
        public MoviesService(CinematronDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Movie> GetMovies()
        {
             return _dbContext.Movies.ToList();
        }
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }
        public async Task AddMovieAsync(Movie movie)
        {
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveMovieAsync(Movie movie)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
