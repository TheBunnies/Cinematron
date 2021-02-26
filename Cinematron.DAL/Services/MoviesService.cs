using Cinematron.DAL.Contracts;
using Cinematron.DAL.Models;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MoviesService> _logger;
        public MoviesService(CinematronDbContext dbContext, ILogger<MoviesService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public List<Movie> GetMovies()
        {
            try
            {
                return _dbContext.Movies.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            return new List<Movie>();
             
        }
        public async Task<Movie> GetMovieAsync(int id)
        {
            try
            {
                return await _dbContext.Movies.FindAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            return await Task.FromResult(new Movie());
        }
        public async Task AddMovieAsync(Movie movie)
        {
            try
            {
                await _dbContext.Movies.AddAsync(movie);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
           
        }
        public async Task RemoveMovieAsync(Movie movie)
        {
            try
            {
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
        }
    }
}
