using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using AmanatakBLL;
using AmanatakBLL.Models;
using Amanatak.Models;
namespace Amanatak.Areas.Operator.Controllers
{
    public class FoundItemsController : Controller
    {
        private AmanatakContext db = new AmanatakContext();

        public ActionResult DashBoard()
        {
            return View();
        }



        // GET: /FoundItems/MissingItem/
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;




            // var item = db.Item.Include(i => i.ItemType).OrderBy(e=>e.ItemType.Name).Select(e=>e);
            var Item = db.Item.Select(e => e).Where(e=>e.ItemCategory==ItemCategory.Found);
            if (Session["SerialNumber"] != null)
                searchString = Session["SerialNumber"].ToString();

            Session["SerialNumber"] = null;
            if (!String.IsNullOrEmpty(searchString))
            {

                Item = Item.Where(c => c.ItemType.Name.Contains(searchString)
                 || c.ItemDetails.Contains(searchString)

                || c.SerialNumber.Contains(searchString)
                || c.AdressFound.Contains(searchString));



            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);


           
            return View(Item.OrderBy(i=>i.Id).ToPagedList(pageNumber, pageSize));
        

        }

 
        // GET: /FoundItems/MissingItem/Details/5
        public ActionResult Details(int? id)
        {
            var item = db.Item.Include(i => i.ItemImages).Where(m => m.Id == id).FirstOrDefault();
            MissingItemViewModel model = new MissingItemViewModel();
             
            model.Item = item;
            model.ItemImagesList = item.ItemImages.ToList();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: /FoundItems/MissingItem/Create
        public ActionResult Create()
        {
            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name");
           


            return View();
        }

        // POST: /FoundItems/MissingItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MissingItemViewModel input)
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
                            input.Item.UserType = UserType.Operator;
                            input.Item.ItemCategory = ItemCategory.Found;


                            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);
                            input.Item.SerialNumber = LastId.ToString() + number;
                            Session["SerialNumber"] = number;
                            input.Item.Deliveried = false;
                            input.Item.ItemView = false;
                            db.Item.Add(input.Item);
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
                            return RedirectToAction("Index");
                        }

                        catch (Exception ex)
                        {
                            dbTran.Rollback();

                        }

                    }
                }
           
            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name", input.Item.ItemTypeId);
            return View(input);
        }

        // GET: /FoundItems/MissingItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Item = db.Item.Include(i => i.ItemImages).Where(m => m.Id == id).FirstOrDefault();
            MissingItemViewModel model = new MissingItemViewModel();
            model.Item = Item;

 
           
            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name", Item.ItemTypeId);
 
            return View(model);
        }

        // POST: /FoundItems/MissingItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MissingItemViewModel Model)
        {
            if (ModelState.IsValid)




                using (var context = new AmanatakContext())
                {

                    using (DbContextTransaction dbTran = context.Database.BeginTransaction())
                    {
                        try
                        {

                            //Save edit Item


                            Model.Item.ItemView = true;
                            Model.Item.UserModified = "Operatort1";//For Prototype
                            Model.Item.DateModified = DateTime.UtcNow.AddHours(3);
                            Model.Item.ItemCategory = ItemCategory.Found;

                            db.Entry(Model.Item).State = EntityState.Modified;
                            db.SaveChanges();

                        

                            //Save new Image
                            for (int i = 0; i < Model.ItemImages.Count; i++)
                            {

                                var file = Model.ItemImages[i];
                                if (file != null && file.ContentLength > 0)
                                {
                                    string FileName = Guid.NewGuid().ToString();
                                    file.SaveAs(Server.MapPath("~/ItemsImages/" + FileName + "-" + file.FileName));
                                    var itemImage = new ItemImages();


                                    itemImage.ImagePath = FileName + "-" + file.FileName;
                                    itemImage.ItemId = Model.Item.Id;
                                    db.ItemImages.Add(itemImage);

                                    db.SaveChanges();

                                }
                            }
                            dbTran.Commit();
                            return RedirectToAction("Index");
                        }

                        catch (Exception ex)
                        {
                            dbTran.Rollback();

                        }

                    }
                }



            ViewBag.ItemTypeId = new SelectList(db.ItemType, "Id", "Name", Model.Item.ItemTypeId);
             return View(Model);



        }

        // GET: /FoundItems/MissingItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = db.Item.Find(id);
           
            
             
            return View(item);
        }

        // POST: /FoundItems/MissingItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}