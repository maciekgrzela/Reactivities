using System;
using Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get(){
            var values = await this._context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/nr
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id){
            var value = await _context.Values.FindAsync(id);
            return Ok(value);
        }

    }
}