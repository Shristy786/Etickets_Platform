using Etickets_Platform.Data.Base;
using Etickets_Platform.Data.ViewModels;
using Etickets_Platform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {

        public readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public  async Task AddNewMovieAsync(NewMovieVm data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                ImageURL = data.ImageURL,
                MovieCategory = data.MovieCategory,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId,

            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
          
            foreach(var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.actor)
                .FirstOrDefaultAsync(n => n.id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropDownsVm> GetNewMovieDropDrownsValues()
        {
            var response = new NewMovieDropDownsVm()
            {
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync()

            };


            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVm data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.id == data.id);

            if(dbMovie!=null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();

            }

            //Remove existing Actors

            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.id);
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actor

            foreach(var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.id,
                    ActorId = actorId

                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();

        }
    }
}
