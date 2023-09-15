using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core.Domain;

namespace Visitor.DataAccess.EntityTypeConfiguration
{
    class VisitorMap : EntityTypeConfiguration<VisitorIdentity>
    {
        internal VisitorMap()
        {
            this.HasKey(x => x.VisitorId);

            this.Property(x => x.VisitorId).HasColumnName("Id");

            this.ToTable("Visitor");
        }
    }
}
