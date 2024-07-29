﻿using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;

namespace Movies.InfraStructure
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
