using System;

namespace LabTest05.Models.ViewModels
{
    public class OrderFoodVM
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int TypeId { get; set; }
        public int FoodItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}