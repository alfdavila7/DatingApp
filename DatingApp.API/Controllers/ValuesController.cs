using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")] //http:localhost:api/values
    [ApiController]
    public class ValuesController : ControllerBase //ControllerBase -For Http responses without view responses
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        //Task: Asynchronous operation that can return a value
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues() //Return Http responses to the client
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        
        [AllowAnonymous]    // Allow requests without Authorization
        [HttpGet("{id}")]   // GET api/values/5
        public async Task<IActionResult> GetValue(int id) //Get id from the Http request. Get response while not blocking the response.
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // Synchronous
        //[HttpGet]
        // public IActionResult GetValues() //Allows us to return Http responses to the client
        // {
        //     var values = _context.Values.ToList();

        //     return Ok(values);
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public IActionResult GetValue(int id) //Get id from the Http request
        // {
        //     var value = _context.Values.FirstOrDefault(x => x.Id == id);

        //     return Ok(value);
        // }

        // POST api/values
        //When we create a record
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        //Edit a record
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
