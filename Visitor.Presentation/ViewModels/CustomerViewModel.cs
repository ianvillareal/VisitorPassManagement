using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitor.Presentation.ViewModels
{
    public class CustomerViewModel
    {

        public long CustomerId { get; set; }

        public List<SubCustomerViewModel> SubCustomers { get; set; }

    }
}