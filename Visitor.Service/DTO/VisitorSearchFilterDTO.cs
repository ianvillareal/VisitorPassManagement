using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Service.DTO
{
    public class VisitorSearchFilterDTO
    {
        public string Company { get; set; }
        public string Visitors { get; set; }
        //Paging specifics
        public int? Offset { get; set; }
        public int? RowCountPerPage { get; set; }
        public string ColumnToSort { get; set; }
        public bool SortAscending { get; set; }
    }
}
