using Etickets_Platform.Data.Base;
using Etickets_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>,ICinemasService
    {
        public CinemasService(AppDbContext context):base(context)
        {

        }
    }
}
