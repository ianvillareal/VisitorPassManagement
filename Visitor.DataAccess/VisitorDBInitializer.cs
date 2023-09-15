using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Core.Domain;

namespace Visitor.DataAccess
{
    public class VisitorDBInitializer : CreateDatabaseIfNotExists<VisitorDBContext>
    {
        protected override void Seed(VisitorDBContext context)
        {
            //CreateVisitors(context);
            //CreateCustomer(context);
            //CreateSite(context);
            //CreateInventorySystem(context);
            //CreateAXItem(context);
            //CreateActivityLog(context);
            //context.SaveChanges();
            //CreateInventoryRequest(context);
            base.Seed(context);
        }

        public void CreateVisitors(VisitorDBContext context)
        {
            
            context.Set<VisitorRequest>().Add(new VisitorRequest()
            {
                Requestor = "Ian",
                Company = "My Company",
                Purpose = Core.PurposeType.Visit
                //VisitorList = new List<string>{ "jb", "rhai" }.ToArray()
             });

            context.Set<VisitorRequest>().Add(new VisitorRequest()
            {
                Requestor = "RN",
                Company = "My Company",
                Purpose = Core.PurposeType.Construction,
                //VisitorList = new List<string>() { "jb", "rhai" }.ToArray(),
                Requirement = new Requirement()
                {
                    Plan = "Plan A",
                    Contractor = "Contractor A",
                    CashBond = "CB",
                    WorkerOrientation = "WO",
                    WorkerList = new List<string>() { "cris", "charles" }.ToArray(),
                }

            });

        }
    }
}
