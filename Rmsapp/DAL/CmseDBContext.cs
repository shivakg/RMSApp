using System;
using System.Collections.Generic;
using System.Data.Entity;
using Rmsapp.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Rmsapp.Models
{
    public class CmseDBContext : DbContext

    {
        public DbSet<Cmse> Cmses { get; set; }
    }
}