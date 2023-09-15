using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.DataAccess.Factory
{
    public static class VisitorDataContextFactory
    {
        public static VisitorDBContext VisitorDBContext()
        {
            VisitorDBContext context = new VisitorDBContext(ConfigurationManager.ConnectionStrings["VisitorDBConnectionString"].ConnectionString);

            context.Configuration.AutoDetectChangesEnabled = false;
            return context;
        }
    }
}
