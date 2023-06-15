using Etickets_Platform.Data.Base;
using Etickets_Platform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {

       

        public ActorsService(AppDbContext context) : base(context) { }
        
     
    }
}
