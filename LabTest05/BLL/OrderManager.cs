using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LabTest05.DAL;
using LabTest05.Models;
using LabTest05.Models.ViewModels;

namespace LabTest05.BLL
{
    public class OrderManager
    {
        OrderGateway _orderGateway = new OrderGateway();

        public string Order(OrderFoodVM orderFood)
        {
            int rowAffected = _orderGateway.Order(orderFood);
            if (rowAffected > 0)
            {
                return "This Order has been saved.";
            }
            return "Order Failed!";
        }

        public List<Member> GetAllMembers()
        {
            return _orderGateway.GetAllMembers();
        }

        public List<FoodItem> GetAllFoodItems()
        {
            return _orderGateway.GetAllFoodItems();
        }

        public List<ItemViewVM> GetItemView(ViewReportVM viewReport)
        {
            return _orderGateway.GetItemView(viewReport);
        }
        public List<ItemViewVM> GetItemView()
        {
            return _orderGateway.GetItemView();
        }
    }
}