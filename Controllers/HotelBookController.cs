using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Work1.Models.viewmodel;
using Work1.Models;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Work1.Controllers
{
    public class HotelBookController : Controller
    {
        HotelRoomContext db = new HotelRoomContext();
        public ActionResult Index()
        {
            var RoombookInfo = (from b in db.BookRooms
                                join r in db.Rooms on b.bookid equals r.bookid
                                
                                join c in db.Customers on b.bookid equals c.bookid
                                select new BookVretrive
                                {
                                    bookid = b.bookid,
                                    checkingdate = b.checkingdate,
                                    checkingOut = b.checkingOut,
                                    duration = b.duration,
                                    cost = b.cost,
                                    custname = c.custname,
                                    
                                    phone = c.phone,
                                   
                                    roomStatus = r.roomStatus,
                                    picturePath = r.picturePath,
                                    roomType1 = r.roomType1,



                                }).ToList();

            return View(RoombookInfo);
        }


        public ActionResult Create()
        {
            //ViewBag.list = new List<string>() { "Single", "Combo", "Twin", "Family Suite", "VIP" };
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookingVM vm)
        {
            string msg = "";
            using (var context=new HotelRoomContext())
            {
                using (DbContextTransaction dbTran = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            if (vm.Image != null)
                            {
                                string file = Path.Combine("~/Images", Guid.NewGuid() + ToString() + Path.GetExtension(vm.Image.FileName));
                                vm.Image.SaveAs(Server.MapPath(file));


                                BookRoom b = new BookRoom { checkingdate = vm.checkingdate, checkingOut = vm.checkingOut, duration = vm.duration, cost = vm.cost };
                                Room r = new Room { roomStatus = vm.roomStatus, picturePath = file, roomType1 = vm.roomType1 };

                                Customers c = new Customers { custname = vm.custname, phone = vm.phone };

                                //ViewBag.list = new List<string>() { "Single", "Combo", "Twin", "Family Suite", "VIP" };
                                db.Customers.Add(c);
                                db.Rooms.Add(r);

                                db.BookRooms.Add(b);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                        }
                    }
                    catch(DbEntityValidationException ex)
                    {
                        dbTran.Rollback();
                        msg = ex.Message;
                        ViewBag.msg = msg;
                    }



                }
            }
                

            return View();
        }
    }
}