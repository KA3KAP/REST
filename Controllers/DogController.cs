using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServerRestAPI.Models;

namespace WebServerRestAPI.Controllers
{
    [Route("[controller]")]
    public class DogController : ControllerBase
    {
        private DogsDbContext _ctx;
        public DogController(DogsDbContext ctx)
        {
            _ctx = ctx;
        }
        // POST dog
        [HttpPost]
        public async Task<ActionResult<Dog>> Post([FromBody] Dog dog)
        {
            if (dog.Tail_Length > 200 || dog.Tail_Length <= 0)
            {
                ModelState.AddModelError("Tail_Length", "Tail Length must be at range from 1 to 200");
            }
            if (dog.Weight > 150 || dog.Weight <= 0)
            {
                ModelState.AddModelError("Weight", "Weight must be at range from 1 to 150");
            }
            // Name already exist
            bool nameAlreadyExists = _ctx.Dogs.Any(x => x.Name == dog.Name);
            if (nameAlreadyExists)
            {
                ModelState.AddModelError("Name", "This dog is already exists");    
            }
            // Error 400
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("JSON", "Invalid JSON is passed in a request body");
                return BadRequest(ModelState);
            }

            _ctx.Dogs.Add(dog);
            await _ctx.SaveChangesAsync();
            return Ok(dog);
        }
        /*public void Post([FromBody] Dog card)
        {
            Dog dog = new Dog();
            dog.Name = card.Name;  // "Doggy";
            dog.Color = card.Color;  //"red";
            dog.Tail_Length = card.Tail_Length;  // 173;
            dog.Weight = card.Weight;  //33;

            _ctx.Dogs.Add(dog);
            _ctx.SaveChanges();
        }*/

        // PUT api/dogs/Neo -> api/dog
        [HttpPut("{name}")]
        public void Put(string name, [FromBody] string value)
        {
            Dog dog = _ctx.Dogs.Find(name);
            dog.Name = value;

            _ctx.SaveChanges();
        }

        // DELETE dogs/id
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Dog dog = _ctx.Dogs.Find(id);
            _ctx.Dogs.Remove(dog);

            _ctx.SaveChanges();
        }
    }
}
