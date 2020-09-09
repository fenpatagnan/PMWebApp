using PMWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.Context
{
    public class ProjectsDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}