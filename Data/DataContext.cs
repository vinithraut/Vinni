﻿using Microsoft.EntityFrameworkCore;
using VinniDatingApp.Entities;

namespace VinniDatingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base (options) { 
        }

        public DbSet<AppUser> Users { get; set; }

    }
}
