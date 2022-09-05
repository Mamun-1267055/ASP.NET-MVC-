using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work1.Models;
using Work1.Models.viewmodel;


namespace Work1.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeDBMVCEntities db = new EmployeeDBMVCEntities();
        public ActionResult Index()
        {
            return View(db.Employees.ToList());

        }
        public ActionResult Create()
        {
            ViewBag.depts = new SelectList(db.Departments, "Id", "Dept");
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpVM tvm)
        {
            if (ModelState.IsValid)
            {
                if (tvm.image != null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(tvm.image.FileName));
                    tvm.image.SaveAs(Server.MapPath(filePath));

                    Employee toys = new Employee
                    {
                       EmpName = tvm.EmpName,
                       Phone = tvm.Phone,
                        Department = tvm.DepartmentId,
                        Picture = filePath,
                       
                    };
                    db.Employees.Add(toys);
                    db.SaveChanges();
                    return PartialView("_success");
                }
               
            }
            ViewBag.depts = new SelectList(db.Departments, "Id", "Dept");
            return PartialView("_error");

        }
        public ActionResult Edit(int id)
        {
           
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            EmpVM tvm = new EmpVM
            {
               EmpId=emp.EmpId,
                EmpName = emp.EmpName,
                Phone = emp.Phone,
                DepartmentId = emp.Department,
                Picture = emp.Picture
            };
            ViewBag.depts = new SelectList(db.Departments, "Id", "Dept"); 
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmpVM tvm)
        {
            if (ModelState.IsValid)
            {
                string filePath = tvm.Picture;
                if (tvm.Picture != null)
                {
                     filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(tvm.image.FileName));
                    tvm.image.SaveAs(Server.MapPath(filePath));

                    Employee emp = new Employee
                    {
                        EmpId = tvm.EmpId,
                        EmpName = tvm.EmpName,
                        Phone = tvm.Phone,
                        Department = tvm.DepartmentId,
                        Picture = filePath,

                    };
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Employee emp = new Employee
                    {
                        EmpId = tvm.EmpId,
                        EmpName = tvm.EmpName,
                        Phone = tvm.Phone,
                        Department = tvm.DepartmentId,
                        Picture = filePath,

                    };
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.depts = new SelectList(db.Departments, "Id", "Dept");
            return View(tvm);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
            
        }



    }
}