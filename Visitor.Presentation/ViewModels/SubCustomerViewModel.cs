using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Visitor.Presentation.ViewModels
{
    public class SubCustomerViewModel
    {
       
        public long SubCustomerId { get; set; }

      
        public string SubCustomerName { get; set; }

       
        public string SubCustomerSSOKey { get; set; }

      
        public string SubCustomerAXReference { get; set; }

     
        public string SubCustomerLegacySystem { get; set; }

        
        public string SubCustomerLegacyReference { get; set; }

       
        public Boolean SubCustomerActivityLogReportSettingEnabled { get; set; }

        
        public string SubCustomerActivityLogReportSettingReceiverEmailAddress { get; set; }

       
            
        public long CustomerId { get; set; }

       
        public int SubCustomerCount { get; set; }

       
        public bool ForAddition { get; set; }
    }
}