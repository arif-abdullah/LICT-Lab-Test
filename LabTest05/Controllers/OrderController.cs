using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTest05.BLL;
using LabTest05.Models;
using LabTest05.Models.ViewModels;

namespace LabTest05.Controllers
{
    public class OrderController : Controller
    {
        OrderManager _orderManager = new OrderManager();
        //
        // GET: /Order/
        public ActionResult Save()
        {
            List<Member> members = _orderManager.GetAllMembers();
            ViewBag.Members = new SelectList(members, "Id", "Code");

            List<FoodItem> foodItems = _orderManager.GetAllFoodItems();
            ViewBag.Foods = new SelectList(foodItems, "Id", "Name");

            return View();
        }
        [HttpPost]
        public ActionResult Save(OrderFoodVM orderFood)
        {
            List<Member> members = _orderManager.GetAllMembers();
            ViewBag.Members = new SelectList(members, "Id", "Code");

            List<FoodItem> foodItems = _orderManager.GetAllFoodItems();
            ViewBag.Foods = new SelectList(foodItems, "Id", "Name");

            if (ModelState.IsValid)
            {
                ViewBag.Message = _orderManager.Order(orderFood);
            }
            return View();
        }

        public JsonResult GetMemberById(int id)
        {
            List<Member> members = _orderManager.GetAllMembers();

            Member member = members.Find(m => m.Id == id);

            return Json(member,JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetFoodItemById(int id)
        {
            List<FoodItem> foodItems = _orderManager.GetAllFoodItems();

            FoodItem foodItem = foodItems.Find(f => f.Id == id);

            return Json(foodItem, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ViewReport()
        {
            List<Member> members = _orderManager.GetAllMembers();
            ViewBag.Members = new SelectList(members, "Id", "Code");

            List<ItemViewVM> itemList = _orderManager.GetItemView();
            ViewBag.Items = itemList;

            return View();
        }

        [HttpPost]
        public ActionResult ViewReport(ViewReportVM viewReport)
        {
            decimal tot = 0;
            List<Member> members = _orderManager.GetAllMembers();
            ViewBag.Members = new SelectList(members, "Id", "Code");

            List<ItemViewVM> itemList = _orderManager.GetItemView(viewReport);
            foreach (var item in itemList)
            {
                tot += item.TotalPrice;
            }
            ViewBag.Items = itemList;
            ViewBag.Tot = tot;
            return View();
        }
	}
}