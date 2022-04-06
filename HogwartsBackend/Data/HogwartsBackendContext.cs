using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HogwartsBackend.Models;

namespace HogwartsBackend.Data
{
    public class HogwartsBackendContext : DbContext
    {
        public HogwartsBackendContext (DbContextOptions<HogwartsBackendContext> options)
            : base(options)
        {
        }

        public DbSet<HogwartsBackend.Models.aspirante> aspirante { get; set; }
    }
}
