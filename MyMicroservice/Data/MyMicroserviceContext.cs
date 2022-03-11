#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Models;

namespace MyMicroservice.Data
{
    public class MyMicroserviceContext : DbContext
    {
        public MyMicroserviceContext (DbContextOptions<MyMicroserviceContext> options)
            : base(options)
        {
        }

        public DbSet<MyMicroservice.Models.Sample> Samples { get; set; }
    }
}
