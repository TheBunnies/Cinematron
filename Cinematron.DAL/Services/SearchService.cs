using Cinematron.DAL.Contracts;
using Cinematron.DAL.Models;
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
        public SearchService(CinematronDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<IWatchable> Search(string query)
        {
            var shows = _dbContext.Shows.Where(x => x.Title.Contains(query)).ToList<IWatchable>();
            var movies = _dbContext.Movies.Where(x => x.Title.Contains(query)).ToList<IWatchable>();

            if (shows.Count <= 0 && movies.Count <= 0)
            {
                return new List<IWatchable>();
            }
            return shows.Concat(movies).OrderBy(x => x.Title).ToList();
        }

    }
}
