using Etickets_Platform.Data.Base;
using Etickets_Platform.Data.ViewModels;
using Etickets_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.Services
{
   public interface IMoviesService :IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownsVm> GetNewMovieDropDrownsValues();
        Task AddNewMovieAsync(NewMovieVm data);

        Task UpdateMovieAsync(NewMovieVm data);
    }
}
