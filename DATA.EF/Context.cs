using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.EF
{
    public partial class Context : DbContext, IEFContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new DbSet<T> Set<T>() where T : BaseEntity => base.Set<T>();

        public Context(DbContextOptions<Context> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
