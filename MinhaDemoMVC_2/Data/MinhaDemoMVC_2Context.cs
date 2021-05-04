using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhaDemoMVC_2.Models;

namespace MinhaDemoMVC_2.Data
{
    public class MinhaDemoMVC_2Context : DbContext
    {
        public MinhaDemoMVC_2Context (DbContextOptions<MinhaDemoMVC_2Context> options)
            : base(options)
        {
        }

        public DbSet<MinhaDemoMVC_2.Models.FilmeScaffold> FilmeScaffold { get; set; }
    }
}
