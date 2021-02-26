using Cinematron.DAL.Contracts;
using Cinematron.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Services
{
    public class ShowsService : IShowsService
    {
        private readonly CinematronDbContext _dbContext;
        private readonly ILogger<ShowsService> _logger;
        public ShowsService(CinematronDbContext dbContext, ILogger<ShowsService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public List<Show> GetShows()
        {
            try
            {
                return _dbContext.Shows.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            return new List<Show>();
             
        }
        public async Task<Show> GetShowAsync(int id)
        {
            try
            {
                return await _dbContext.Shows.Include(x => x.Episodes).FirstAsync(x => x.Id == id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            return await Task.FromResult(new Show());
        }
        public async Task AddShowAsync(Show show)
        {
            try
            {
                await _dbContext.Shows.AddAsync(show);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            
        }
        public async Task RemoveShowAsync(Show show)
        {
            try
            {
                _dbContext.Shows.Remove(show);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
        }
        public async Task AddEpisodeAsync(Show show, Episode episode)
        {
            try
            {
                episode.Show = show;
                await _dbContext.Episodes.AddAsync(episode);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            
        }
        public async Task RemoveEpisodeAsync(Episode episode)
        {
            try
            {
                _dbContext.Episodes.Remove(episode);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
               _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            
        }
    }
}
