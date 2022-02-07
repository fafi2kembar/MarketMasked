#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarketMasked.Models;

    public class MarketMaskedContext : DbContext
    {
        public MarketMaskedContext (DbContextOptions<MarketMaskedContext> options)
            : base(options)
        {
        }

        public DbSet<MarketMasked.Models.Item> Item { get; set; }
    }
