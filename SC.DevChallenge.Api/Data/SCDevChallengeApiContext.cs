using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.DevChallenge.Api.Models;

namespace SC.DevChallenge.Api.Data
{
    public class SCDevChallengeApiContext : DbContext
    {
        public SCDevChallengeApiContext (DbContextOptions<SCDevChallengeApiContext> options)
            : base(options)
        {
        }

        public DbSet<InstrumentPrice> Prices { get; set; }
    }
}
