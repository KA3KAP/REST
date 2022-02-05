using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServerRestAPI.Models
{
    public class DogsDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }
    public DogsDbContext(DbContextOptions<DogsDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
}
