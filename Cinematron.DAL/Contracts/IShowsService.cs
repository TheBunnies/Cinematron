using Cinematron.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Contracts
{
    public interface IShowsService
    {
        List<Show> GetShows();
        Task<Show> GetShowAsync(int id);
        Task AddShowAsync(Show show);
        Task RemoveShowAsync(Show show);
        Task AddEpisodeAsync(Show show, Episode episode);
        Task RemoveEpisodeAsync(Episode episode);
    }
}
