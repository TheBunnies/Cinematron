using Cinematron.DAL.Contracts;
using Cinematron.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        public ShowsService(CinematronDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Show> GetShows()
        {
             return _dbContext.Shows.ToList();
        }
        public async Task<Show> GetShowAsync(int id)
        {
            return await _dbContext.Shows.Include(x => x.Episodes).FirstAsync(x => x.Id == id);
        }
        public async Task AddShowAsync(Show show)
        {
            await _dbContext.Shows.AddAsync(show);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveShowAsync(Show show)
        {
             _dbContext.Shows.Remove(show);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddEpisodeAsync(Show show, Episode episode)
        {
            episode.Show = show;
            await _dbContext.Episodes.AddAsync(episode);
            await _dbContext.SaveChangesAsync();
        }
        public async Task RemoveEpisodeAsync(Episode episode)
        {
            _dbContext.Episodes.Remove(episode);
            await _dbContext.SaveChangesAsync();
        }
    }
}
