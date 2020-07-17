using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.EF
{
    public partial class Context
    {
        public DbSet<TodoList> TodoList { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
