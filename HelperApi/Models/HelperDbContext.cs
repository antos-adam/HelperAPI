using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelperApi.Models
{
    public class HelperDbContext : DbContext
    {
        public HelperDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
