using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Contentful.Options
{
    public class DBContext : System.Data.Entity.DbContext
    {
        public int DatabaseConnection { get; set; }
    }
}
