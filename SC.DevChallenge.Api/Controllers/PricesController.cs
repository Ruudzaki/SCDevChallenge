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
    public class PricesController : ControllerBase
    {
        private readonly SCDevChallengeApiContext _context;

        public PricesController(SCDevChallengeApiContext context)
        {
            _context = context;
        }

        // GET: api/Prices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prices>>> GetPrices()
        {
            return await _context.Prices.ToListAsync();
        }

        [HttpGet("average")]
        public string Average()
        {
            return "I'm dummy controller";
        }

        private bool PricesExists(int id)
        {
            return _context.Prices.Any(e => e.Id == id);
        }
    }
}
