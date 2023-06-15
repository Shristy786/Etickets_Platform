using Etickets_Platform.Data;
using Etickets_Platform.Data.Services;
using Etickets_Platform.Data.Static;
using Etickets_Platform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        //constructor injection to inject dbcontext 
        public ActorsController(IActorsService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        public async Task< IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
         
        //GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Create([Bind("ProfilePictureURL,FullName,Bio")]Actor actor)
        {
             if(!ModelState.IsValid)
            {
                return View(actor);
            }

          await  _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        //GET:Actors/Details/1
        public async Task<IActionResult>Details(int id)
        {
            var actorDetails = await  _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(int id,[Bind("id,ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("id,ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

