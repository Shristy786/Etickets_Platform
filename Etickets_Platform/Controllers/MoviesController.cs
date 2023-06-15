using Etickets_Platform.Data;
using Etickets_Platform.Data.Services;
using Etickets_Platform.Data.Static;
using Etickets_Platform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {

        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.cinema);
            return View(allMovies);
        }

        [AllowAnonymous]

        public async Task<IActionResult>Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.cinema);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString)
                || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);

            }
            return View("Index", allMovies);
        }

        //GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //GET:Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropDownsData = await _service.GetNewMovieDropDrownsValues();
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "id", "FullName");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVm movie)
        {

            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _service.GetNewMovieDropDrownsValues();
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "id", "FullName");
                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "id", "Name");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "id", "FullName");

                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }


        //GET:Movies/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVm()
            {
                id = movieDetails.id,
                Name = movieDetails.Name,
                Price=movieDetails.Price,
                Description = movieDetails.Description,
                ImageURL = movieDetails.ImageURL,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                CinemaId = movieDetails.CinemaId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };
            var movieDropDownsData = await _service.GetNewMovieDropDrownsValues();
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "id", "FullName");

            return View(response);



        }
        [HttpPost]
        public  async Task<IActionResult>Edit(int id,NewMovieVm movie)
        {
            if (id != movie.id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _service.GetNewMovieDropDrownsValues();
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "id", "FullName");
                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "id", "Name");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "id", "FullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}


