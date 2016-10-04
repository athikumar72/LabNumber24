using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabNumber24.Models;
using System.Net;
using System.Data.Entity;

namespace LabNumber24.Controllers
{
    public class CustomerController : Controller
    {


        [HttpGet]
        public ActionResult Menu()
        {

            return View();
        }
        // GET: Customer
        public ActionResult List()
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            List<Customer> customers = dbcontext.Customers.ToList();
            return View(customers);

        }

        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customerCreate)
        {
            try
            {
                NorthwindEntities dbcontext = new NorthwindEntities();
                Customer customers = dbcontext.Customers.Add(customerCreate);
                dbcontext.SaveChanges();
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                return View();
            }

        }

        // GET: Customer/Edit/5
        [HttpGet]
        public ActionResult Edit(string id)
        {
            NorthwindEntities dbcontext = new NorthwindEntities();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = dbcontext.Customers.Find(id);
            //if (customers == null)
            // {
            //    return HttpNotFound();
            // }
            return View(customers);

        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Customer customers)
        {

            try
            {
                NorthwindEntities dbcontext = new NorthwindEntities();
                if (ModelState.IsValid)
                {
                    dbcontext.Entry(customers).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                return View(customers);
            }


        }
        

        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult Delete(string id)
        {
            NorthwindEntities dbcontext = new NorthwindEntities();

            Customer customers = dbcontext.Customers.Find(id);
            return View(customers);
        }

        // POST: Customer/Delete/5
        [HttpPost]
       public ActionResult Delete(string id, Customer customers)//FormCollection collection)
           // public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                NorthwindEntities dbcontext = new NorthwindEntities();
                Customer customer = dbcontext.Customers.Find(id);
                  Order_Detail orderDetail1 = new Order_Detail();
                var orders = dbcontext.Orders.Where(x => x.CustomerID == id);
                var orderDetailRecords = from Order in dbcontext.Orders
                                         join orderDetail in dbcontext.Order_Details on Order.OrderID equals orderDetail.OrderID
                                         select orderDetail;
                // List<Order> orders = dbcontext.Orders.Where(x => x.CustomerID == id).ToList();
                //  List <Order_Detail>orderDetails=dbcontext.Order_Details.Where(x =>x.OrderId in or 
                // var innerJoinQuery 
                //  Customer customer = new Customer();

                // dbcontext.Customers.Remove(customers);
                // dbcontext.SaveChanges();

                //  if (orders.Count > 0)

                dbcontext.Order_Details.RemoveRange(orderDetailRecords.ToList());
                dbcontext.Orders.RemoveRange(orders.ToList());

                dbcontext.Customers.Remove(customer);
                dbcontext.SaveChanges();

                return RedirectToAction("List");
            }

            // TODO: Add delete logic here


            catch (Exception ex)
            {
                ViewBag.ExceptionMessage = ex.Message + ex.InnerException.Message;
                return View(customers);
            }


          
        }
    }
}
