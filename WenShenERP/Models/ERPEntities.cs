using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WenShenERP.Models
{
    public class ERPEntities:DbContext
    {
        public DbSet<Province> Provinces { get; set; }
    }
}