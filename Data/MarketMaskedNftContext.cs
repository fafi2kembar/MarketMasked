#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarketMasked.Models;

    public class MarketMaskedNftContext : DbContext
    {
        public MarketMaskedNftContext (DbContextOptions<MarketMaskedNftContext> options)
            : base(options)
        {
        }

        public DbSet<MarketMasked.Models.Nft> Nft { get; set; }
    }
