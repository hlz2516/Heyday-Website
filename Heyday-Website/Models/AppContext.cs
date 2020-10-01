﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Bug> Bugs { get; set; }

        public AppContext(DbContextOptions<AppContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
