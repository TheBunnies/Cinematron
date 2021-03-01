using Cinematron.DAL.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinematron.Controllers
{
    public class VideoController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IMoviesService _moviesService;
        private readonly IShowsService _showsSerivce;
        public VideoController(IWebHostEnvironment appEnvironment, IMoviesService moviesService, IShowsService showsSerivce)
        {
            _appEnvironment = appEnvironment;
            _moviesService = moviesService;
            _showsSerivce = showsSerivce;
        }
        public FileResult GetVideo(string path)
        {
             return PhysicalFile($"{_appEnvironment.WebRootPath}{path}", "application/octet-stream", enableRangeProcessing: true);
        }
        [HttpGet]
        public async Task<IActionResult> Movie(int id)
        {
            var model = await _moviesService.GetMovieAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            var model = await _showsSerivce.GetShowAsync(id);
            return View(model);
        }
    }
}
