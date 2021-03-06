﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartphoneShop.Models;
using SmartphoneShop.Services;
using SmartphoneShop.ViewModels;

namespace SmartphoneShop.Controllers
{
    public class StoreController : Controller
    {
        private readonly GadgetServices _gadgetServices = new GadgetServices();
        private readonly OrderServices _orderServices = new OrderServices();


        [HttpGet]
        public IActionResult GadgetList()
        {
            var gadgets = _gadgetServices.GetAll();
            var model = _gadgetServices.MapperInit().Map<IEnumerable<GadgetViewModel>>(gadgets);
            return View(model);
        }

        [HttpGet]
        public IActionResult Order(int gadgetId)
        {
            var gadget = _gadgetServices.GetGadget(gadgetId);
            HttpContext.Session.SetInt32("GadgetId", gadgetId);
            var model = _gadgetServices.MapperInit().Map<GadgetViewModel>(gadget);
            return View(model);
        }

        [HttpPost]
        public IActionResult Order(IFormCollection collection)
        {
            var id = HttpContext.Session.GetInt32("GadgetId");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var address = collection["Address"].ToString();
            var phone = collection["PhoneNumber"].ToString();

            _orderServices.AddOrder(
                new OrderModel
                {
                    GadgetId = id,
                    UserId = userId,
                    Address = address,
                    PhoneNumber = phone
                });

            return RedirectToAction("GadgetList", "Store");
        }

        [HttpGet]
        public IActionResult UserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_orderServices.GetUserOrders(userId));
        }

        public IActionResult Details(int gadgetId)
        {
            var gadget = _gadgetServices.GetGadget(gadgetId);
            var model = _gadgetServices.MapperInit().Map<GadgetViewModel>(gadget);
            return View(model);
        }

        [HttpGet]
        public IActionResult EditCartItem(int orderId)
        {
            var order = _orderServices.GetById(orderId);
            HttpContext.Session.SetInt32("orderId", orderId);
            var model = _orderServices.MapperInit().Map<OrderViewModel>(order);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditCartItem(IFormCollection collection)
        {
            var nullableOrderId = HttpContext.Session.GetInt32("orderId");
            var orderId = nullableOrderId ?? throw new NullReferenceException("Id cannot be null");
            var address = collection["Address"].ToString();
            var phoneNumber = collection["PhoneNumber"].ToString();
            var orderObj = _orderServices.GetById(orderId);
            orderObj.Address = address;
            orderObj.PhoneNumber = phoneNumber;
            _orderServices.Update(orderObj);
            _orderServices.Save();
            return RedirectToAction("UserCart");
        }

        [HttpGet]
        public IActionResult DeleteCartItem(int orderId)
        {
            var order = _orderServices.GetById(orderId);
            HttpContext.Session.SetInt32("DeleteOrderId", orderId);
            var model = _orderServices.MapperInit().Map<OrderViewModel>(order);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteCartItem()
        {
            var nullableId = HttpContext.Session.GetInt32("DeleteOrderId");
            var orderId = nullableId ?? throw new NullReferenceException("Id cannot be null");
            var order = _orderServices.GetById(orderId);
            _orderServices.Delete(order);
            _orderServices.Save();
            return RedirectToAction("UserCart");
        }
    }
}