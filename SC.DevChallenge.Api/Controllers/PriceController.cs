using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SC.DevChallenge.Api.Application;
using SC.DevChallenge.Api.Data;
using SC.DevChallenge.Api.Models;

namespace SC.DevChallenge.Api.Controllers
{
    [Route("api/prices")]
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
        public async Task<ActionResult<AveragePriceViewModel>> Average(string portfolio, string owner, string instrument,
            DateTime? date = null)
        {
            if (date != null)
            {
                var averagePrice = new Calculator(_context).CalculateAveragePrice(portfolio, owner, instrument, (DateTime) date);
                var averagePriceViewModel = new AveragePriceViewModel()
                {
                    Price = averagePrice.Average,
                    Date = averagePrice.StartDate
                };

                return averagePriceViewModel;
            }
            else
            {
                var averagePrice = new Calculator(_context).CalculateAveragePrice(portfolio, owner, instrument);
                var averagePriceViewModel = new AveragePriceViewModel()
                {
                    Price = averagePrice.Average,
                    Date = averagePrice.StartDate
                };

                return averagePriceViewModel;

            }
        }
    }
}
