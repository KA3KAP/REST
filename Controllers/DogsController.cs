using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServerRestAPI.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebServerRestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class DogsController : ControllerBase
    {
        private DogsDbContext _ctx;
        public DogsController(DogsDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET dogs
        [HttpGet]
        public ActionResult<IEnumerable<Dog>> Get(/*DogsParameters dogsParameters*/)
        {
            var dogs = _ctx.Dogs./*OrderBy(x => x.Tail_Length)/*.Skip((dogsParameters.PageNumber - 1) * dogsParameters.PageSize).Take(dogsParameters.PageSize)*/ToList();
            return dogs;
        }

        // GET dogs/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> Get(int id)
        {
            Dog dog = await _ctx.Dogs.FirstOrDefaultAsync(x => x.Id == id);
            if (dog == null)
                return NotFound();
            return new ObjectResult(dog);
        }

        //public async Task<IActionResult> Index(SortState sortOrder = SortState.Tail_LengthDesc)
        //{
        //    IQueryable<Dog> dogs = _ctx.Dogs;

        //    ViewData["Tail_LengthSort"] = sortOrder == SortState.Tail_LengthDesc ? SortState.Tail_LengthAsc : SortState.Tail_LengthDesc;
        //    ViewData["NameSort"] = sortOrder == SortState.NameDesc ? SortState.NameAsc : SortState.NameDesc;
        //    ViewData["ColorSort"] = sortOrder == SortState.ColorDesc ? SortState.ColorAsc : SortState.ColorDesc;
        //    ViewData["WeightSort"] = sortOrder == SortState.WeightDesc ? SortState.Tail_LengthAsc : SortState.Tail_LengthDesc;

        //    dogs = sortOrder switch
        //    {
        //        SortState.Tail_LengthDesc => dogs.OrderByDescending(s => s.Tail_Length),
        //        _ => dogs.OrderBy(s => s.Name),

        //    };

        //    return View(await dogs.AsNoTracking().ToListAsync());
        //}

        // 




        
    }
}
