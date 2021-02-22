using Cinematron.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematron.DAL.Contracts
{
    public interface IMoviesService
    {
        List<Movie> GetMovies();
        Task<Movie> GetMovieAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task RemoveMovieAsync(Movie movie);
    }
}
