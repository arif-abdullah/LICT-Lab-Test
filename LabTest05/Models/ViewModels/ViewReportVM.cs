using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTest05.Models.ViewModels
{
    public class ViewReportVM
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int TypeId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}