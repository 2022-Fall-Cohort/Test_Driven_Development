using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiMVC.Models;

namespace WebApiMVC.Data
{
    public class WebApiMVCContext : DbContext
    {
        public WebApiMVCContext (DbContextOptions<WebApiMVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiMVC.Models.VideoGame> VideoGame { get; set; } = default!;
    }
}
