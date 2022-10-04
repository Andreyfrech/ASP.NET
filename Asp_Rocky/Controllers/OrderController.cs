using Asp_Rocky.Data;
using Asp_Rocky.Models;
using Asp_Rocky.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Asp_Rocky.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OrderController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            IEnumerable<Orders> objList1 = _db.Orders;

            foreach (var obj in objList1)
            {
            //    //obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            //    obj.Status = _db.Status.FirstOrDefault(u => u.Id == obj.StatusId);
            }

            return View(objList1);
        }

        public IActionResult Upsert(int? id)
        {
           
            OrderVM OrderVM = new OrderVM()
            {
                Orders = new Orders(),
                OrdersSelectList = _db.Status.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };


            if (id == null)
            {
                return View(OrderVM);
            }
            else
            {
                OrderVM.Orders = _db.Orders.Find(id);
                if (OrderVM.Orders == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    return View(OrderVM);
                }
                return View(OrderVM);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(OrderVM OrderVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (OrderVM.Orders.Id == 0)
                {
                    //create
                    _db.Orders.Add(OrderVM.Orders);
                }
                else
                {
                    //update
                    var objFromDb = _db.Orders.AsNoTracking().FirstOrDefault(u => u.Id == OrderVM.Orders.Id);

                    _db.Orders.Update(OrderVM.Orders);
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            OrderVM.OrdersSelectList = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
            return View(OrderVM);
        }
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Orders Orders = _db.Orders.Include(u => u.Status).FirstOrDefault(u => u.Id == id);
            //Orders.Category = _db.Category.Find(Orders.CategoryId);
            if (Orders == null)
            {
                return NotFound();
            }

            return View(Orders);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Orders.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Orders.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
