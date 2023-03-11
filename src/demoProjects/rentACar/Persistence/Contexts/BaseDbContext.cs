using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    internal class BaseDbContext : DbContext
    {
      public DbSet<Brand> Brands { get; set; }
    }
}
