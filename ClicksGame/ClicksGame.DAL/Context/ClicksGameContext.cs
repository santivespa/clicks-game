using ClicksGame.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClicksGame.DAL.Context
{
    public class ClicksGameContext : DbContext
    {

        public DbSet<MainCounter> Counter { get; set; }

        public DbSet<Ranking> Rankings { get; set; }

        public ClicksGameContext(DbContextOptions<ClicksGameContext> options)
          : base(options)
        {

        }

    }
}
