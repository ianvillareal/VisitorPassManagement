using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core;
using Visitor.Core.Domain;

namespace Visitor.DataAccess.EntityTypeConfiguration
{
    class VisitorRequestMap : EntityTypeConfiguration<VisitorRequest>
    {
        internal VisitorRequestMap()
        {
            this.HasKey(x => x.RequestId);

            this.Property(x => x.RequestId).HasColumnName("Id");

            this.HasOptional(v => v.Requirement)
                .WithRequired(r => r.ParentRequest)
                .Map(m => m.MapKey("RequestId"))
                .WillCascadeOnDelete();

            //Visitor mapping
            this.HasMany(x => x.Visitors)
                .WithRequired(x => x.ParentRequest)
                .HasForeignKey(x => x.RequestId);
            
            this.ToTable("VisitorRequest");
        }
    }
}
