using Etickets_Platform.Data;
using Etickets_Platform.Data.Services;
using Etickets_Platform.Data.Static;
using Etickets_Platform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Etickets_Platform.Controllers
{
    [Authorize (Roles =UserRoles.Admin)]
    public class ProducersController : Controller
    {


        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        [AllowAnonymous]
        //GET:Producers/Details/1

        public async Task<IActionResult>Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        //GET:Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }


        //GET:producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails=await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {

            if (!ModelState.IsValid) return View(producer);

            if(id==producer.id)
            {
                await _service.UpdateAsync(id,producer);
                return RedirectToAction(nameof(Index));
            }

            return View(producer);
            
        }
        //GET:producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {

            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }

       


    }
}
