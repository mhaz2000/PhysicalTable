using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Data.Models;

namespace Data.Context
{
    public class PhysicalDB:DbContext
    {
        public PhysicalDB()
        {

        }
        public DbSet<Log> Logs { get; set; }
    }
}