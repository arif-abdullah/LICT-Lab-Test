using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabTest05.Models.ViewModels
{
    public class MemberVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Type { get; set; }
    }
}