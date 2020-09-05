using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditManagement.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Auditors> Auditors { get; set; }
        public DbSet<AuditClientPortfolio> Portfolio { get; set; }
        public DbSet<AuditRequest> AuditRequest { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
