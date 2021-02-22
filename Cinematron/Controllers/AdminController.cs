using Cinematron.DAL.Contracts;
using Cinematron.DAL.Models;
using Cinematron.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematron.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMoviesService _moviesService;
        private readonly IShowsService _showsSerivce;
        public AdminController(IWebHostEnvironment appEnvironment, IMoviesService moviesService, IShowsService showsService)
        {
            _appEnvironment = appEnvironment;
            _moviesService = moviesService;
            _showsSerivce = showsService;
        }
        public IActionResult MoviesAdminPanel()
        {
            return View();
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MoviesAdminPanel(MovieAddViewModel model)
        { 
            if (ModelState.IsValid)
            {
                string titlePath = "/Images/titles/" + model.Title.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + titlePath, FileMode.Create))
                {
                    await model.Title.CopyToAsync(fileStream);
                }
                string videoPath = "/Videos/movies/" + model.Movie.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + videoPath, FileMode.Create, FileAccess.Write))
                {
                    await model.Movie.CopyToAsync(fileStream);
                }

                var movie = new Movie
                {
                    ThumbnailUrl = titlePath,
                    VideoUrl = videoPath,
                    Duration = model.Duration,
                    Description = model.Description,
                    Title = model.Name
                };
                await _moviesService.AddMovieAsync(movie);
                ViewBag.Success = "Everything worked as expected :)";
            }
            return View(model);
        }
        public IActionResult SeriesAdminPanel()
        {
            return View();
        }
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeriesAdminPanel(ShowAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string titlePath = "/Images/titles/" + model.Title.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + titlePath, FileMode.Create))
                {
                    await model.Title.CopyToAsync(fileStream);
                }
                string rootPath = "/Videos/shows/" + model.Name;
                Directory.CreateDirectory(_appEnvironment.WebRootPath + rootPath);
                var show = new Show {
                    Title = model.Name,
                    ThumbnailUrl = titlePath,
                    Duration = model.AverageDuration,
                    Description = model.Description
                };
                await _showsSerivce.AddShowAsync(show);
                foreach(var episode in model.Episodes)
                {
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath +$"{rootPath}/{episode.FileName}", FileMode.Create))
                    {
                        await episode.CopyToAsync(fileStream);
                    }
                    await _showsSerivce.AddEpisodeAsync(show, new Episode { VideoUrl = $"{rootPath}/{episode.FileName}"});
                }
                ViewBag.Success = "Everything worked as expected :)";
            }
            return View(model);
        }

    }
}
