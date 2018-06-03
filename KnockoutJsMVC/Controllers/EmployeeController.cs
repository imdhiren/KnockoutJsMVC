using KnockoutJsMVC.Edmx;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KnockoutJsMVC.Controllers
{
    public class EmployeeController : Controller
    {
        KnockoutJsMVCEntities _contect = new KnockoutJsMVCEntities();
        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public string Create(Employee employee)
        {
            if (!ModelState.IsValid) return "Model is invalid";
            _contect.Employees.Add(employee);
            _contect.SaveChanges();
            return "Cource is created";
        }

        // GET: Home
        public ActionResult Read()
        {
            return View();
        }
        //GET All Courses
        public JsonResult ListEmployees()
        {
            return Json(_contect.Employees.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var employee = _contect.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();
            var serializer = new JavaScriptSerializer();
            ViewBag.selectedEmployee = serializer.Serialize(employee);
            return View();
        }

        // POST: Home/Update/5
        [HttpPost]
        public string Update(Employee employee)
        {
            if (!ModelState.IsValid) return "Invalid model";
            _contect.Entry(employee).State = EntityState.Modified;
            _contect.SaveChanges();
            return "Updated successfully";
        }
        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var employee = _contect.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();
            var serializer = new JavaScriptSerializer();
            ViewBag.selectedEmployee = serializer.Serialize(employee);
            return View();
        }
        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public string Delete(Employee employee)
        {
            if (employee == null) return "Invalid data";
            var getCourse = _contect.Employees.Find(employee.Id);
            _contect.Employees.Remove(getCourse);
            _contect.SaveChanges();
            return "Deleted successfully";
        }
    }
}