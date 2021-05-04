using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC_5.Models;

namespace MinhaDemoMVC_5.Data
{
    public class MinhaDemoMVC_5Context : DbContext
    {
        public MinhaDemoMVC_5Context (DbContextOptions<MinhaDemoMVC_5Context> options)
            : base(options)
        {
        }

        public DbSet<MinhaDemoMVC_5.Models.FilmeScaffold> FilmeScaffold { get; set; }
    }
}
