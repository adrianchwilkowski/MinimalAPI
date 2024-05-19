﻿using Microsoft.EntityFrameworkCore;
using MinimalApiProject.Models;

namespace MinimalApiProject.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Osoby> Osoby => Set<Osoby>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}