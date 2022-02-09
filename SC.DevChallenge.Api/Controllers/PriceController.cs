using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.DevChallenge.Api.Data;
using SC.DevChallenge.Api.Models;

namespace SC.DevChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly SCDevChallengeApiContext _context;

        public PriceController(SCDevChallengeApiContext context)
        {
            _context = context;
        }

        // GET: api/Price
        [HttpGet("price")]
        public async Task<ActionResult<InstrumentPrice>> GetPrice(int id)
        {
            return await _context.Prices.FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpGet("average")]
        public string Average()
        {
            return $"I'm dummy controller. There are {_context.Prices.Count()} price records";
        }
    }
}
