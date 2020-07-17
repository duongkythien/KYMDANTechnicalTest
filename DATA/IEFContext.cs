using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DATA
{
    public interface IEFContext
    {
        DbSet<T> Set<T>() where T : BaseEntity;
    }
}
