using Microsoft.EntityFrameworkCore;
using MyRecordCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRecordCollection.Services
{
    public class AlbumDBContext : DbContext
    {
        public AlbumDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AlbumDAL> Albums { get; set; }
    }
}
