using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core.Domain;
using Visitor.DataAccess.EntityTypeConfiguration;
using Visitor.DataAccess.Factory;

namespace Visitor.DataAccess
{
    public class VisitorDBContext : IdentityDbContext<ApplicationUser>
    {
        public VisitorDBContext() : base("name=VisitorDBConnectionString")
        {
            Database.SetInitializer<VisitorDBContext>(new VisitorDBInitializer());
        }

        public VisitorDBContext(string ConnectionString) : base(ConnectionString)
        {
            Database.SetInitializer<VisitorDBContext>(new VisitorDBInitializer());
        }


        public static VisitorDBContext Create()
        {
            return VisitorDataContextFactory.VisitorDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new VisitorMap());
            modelBuilder.Configurations.Add(new VisitorRequestMap());
            modelBuilder.Configurations.Add(new RequirementMap());
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public virtual DbSet<VisitorIdentity> Visitors { get; set; }
        public virtual DbSet<VisitorRequest> VisitorRequests { get; set; }
        public virtual DbSet<Requirement> Requirements { get; set; }
    }
}
