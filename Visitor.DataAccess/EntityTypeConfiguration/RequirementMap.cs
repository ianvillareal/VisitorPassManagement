using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core.Domain;

namespace Visitor.DataAccess.EntityTypeConfiguration
{
    class RequirementMap : EntityTypeConfiguration<Requirement>
    {
        internal RequirementMap()
        {
            this.HasKey(x => x.RequirementId);

            this.Property(x => x.RequirementId).HasColumnName("Id");

            this.ToTable("Requirement");
        }
    }
}
