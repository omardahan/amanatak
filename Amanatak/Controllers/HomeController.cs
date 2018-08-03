using Amanatak.Models;
using AmanatakBLL;
using AmanatakBLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amanatak.Controllers
{
    public class HomeController : Controller
    {
        private AmanatakContext db = new AmanatakContext();

        public ActionResult CreateItemMission()
        {
            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name");
            ViewBag.IdentificationID = new SelectList(db.IdentificationType, "Id", "Name");
            ViewBag.NationalityId = new SelectList(db.Countries, "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItemMission(MissingItemViewModel input)
        {
            if (ModelState.IsValid)

                using (var context = new AmanatakContext())
                {

                    using (DbContextTransaction dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            //Get Last Item Id

                            var LastId = 0;
                            var item = db.Item.Select(e => e).FirstOrDefault();
                            if (item != null)
                                LastId = db.Item.OrderByDescending(p => p.Id).FirstOrDefault().Id;

                            //Save Item
                            input.Item.UserId = 1;//For Prototype
                            input.Item.UserType = UserType.Guest;
                            input.Item.ItemCategory = ItemCategory.Missing;

                            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
                            input.Item.SerialNumber = LastId.ToString() + number;
                            Session["SerialNumber"] = number;
                            input.Item.Deliveried = false;
                            input.Item.ItemView = false;
                            db.Item.Add(input.Item);
                            db.SaveChanges();
                            //Save Owner
                            input.ItemOwner.ItemId = input.Item.Id;
                            db.ItemOwner.Add(input.ItemOwner);
                            db.SaveChanges();

                            //Save Image
                            for (int i = 0; i < input.ItemImages.Count; i++)
                            {

                                var file = input.ItemImages[i];
                                if (file != null && file.ContentLength > 0)
                                {
                                    string FileName = Guid.NewGuid().ToString();
                                    file.SaveAs(Server.MapPath("~/ItemsImages/" + FileName + "-" + file.FileName));
                                    var itemImage = new ItemImages();


                                    itemImage.ImagePath = FileName + "-" + file.FileName;
                                    itemImage.ItemId = input.Item.Id;
                                    db.ItemImages.Add(itemImage);

                                    db.SaveChanges();

                                }
                            }
                            dbTran.Commit();
                            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name");
                            ViewBag.IdentificationID = new SelectList(db.IdentificationType, "Id", "Name");
                            ViewBag.NationalityId = new SelectList(db.Countries, "Id", "Name");
                            @TempData["SerialNumber"] = " <script>alert('تم تقديم الطلب برقم "+ number + " ');</script>";
                             return View();
                        }

                        catch (Exception ex)
                        {
                            dbTran.Rollback();

                        }

                    }
                }
            ViewBag.IdentificationID = new SelectList(db.IdentificationType, "Id", "Name", input.ItemOwner.IdentificationID);
            ViewBag.NationalityId = new SelectList(db.Countries, "Id", "Name", input.ItemOwner.Nationality);

            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name", input.Item.ItemTypeId);
            return View(input);
        }


        public ActionResult QueryForItem()
        {
            MissingItemViewModel model = new MissingItemViewModel();

            return View(model);

        }

        [HttpPost]
            public ActionResult QueryForItem(string SerialNumber)
        {
            if (SerialNumber == null)
            {
                return View();
            }
             var ItemOwner = db.ItemOwner.Include(i => i.Item).Where(m => m.Item.SerialNumber == SerialNumber).FirstOrDefault();
            if (ItemOwner == null)
            {
                TempData["Error"] = "تأكد من رقم الطلب";
              return  RedirectToAction("QueryForItem", new { SerialNumber = SerialNumber });

                
            }
            MissingItemViewModel model = new MissingItemViewModel();
            model.ItemOwner = ItemOwner;
            model.Item = ItemOwner.Item;
            model.ItemImagesList = ItemOwner.Item.ItemImages.ToList();
           
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}