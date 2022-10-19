using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Widget> Widget { get; set; } = default!;

        public DbSet<Widget2> Widget2 { get; set; } = default!;

        public DbSet<Widget3> Widget3 { get; set; } = default!;

        public DbSet<Widget4> Widget4 { get; set; } = default!;

        public DbSet<Widget5> Widget5 { get; set; } = default!;
    }
