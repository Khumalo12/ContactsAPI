using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Phonebook> Phonebook { get; set; }


    }
}
