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
    public class SearchService : ISearchService
    {
        private readonly CinematronDbContext _dbContext;
        private readonly ILogger<SearchService> _logger;
        public SearchService(CinematronDbContext dbContext, ILogger<SearchService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public List<IWatchable> Search(string query)
        {
            try
            {
                var shows = _dbContext.Shows.Where(x => x.Title.Contains(query)).ToList<IWatchable>();
                var movies = _dbContext.Movies.Where(x => x.Title.Contains(query)).ToList<IWatchable>();

                if (shows.Count <= 0 && movies.Count <= 0)
                {
                    return new List<IWatchable>();
                }
                return shows.Concat(movies).OrderBy(x => x.Title).ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{this.GetType().Name} threw an exception with the following description: {ex.Message}");
            }
            return new List<IWatchable>();
        }

    }
}
