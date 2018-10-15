using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BSheets.Models.Custom
{
    public partial class BSheetsEntities : DbContext
    {
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CustomerDb> Customers { get; set; }
    }
}