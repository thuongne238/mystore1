using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mystore1.Models;

namespace mystore1.Areas.admin.Controllers
{
    public class CategoriesController : Controller
    {
        private mystoreEntities db = new mystoreEntities();

        // GET: admin/Categories
        //get: lấy dữ liệu từ bảng cate trong date base để hiển thị lên
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: admin/Categories/Details/5
        //detail: lấy chi tiết 1 bản ghi có khóa là cateId = id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//mã lỗi 400 không tìm thây giá trị truyền vào
            }
            Category category = db.Categories.Find(id);
            if (category == null)//không tìm thấy bản ghi
            {
                return HttpNotFound();//mã lỗi 404
            }
            return View(category);
        }
        
        // GET: admin/Categories/Create
        //lấy 1 bản ghi từ database và hiển thị lêm form create
        //load form create
        //[httpGet] là phương thức mặc định, nên không cần khai báo từ khóa
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Categories/Create
        //lwu dwx liệu  nhâp vào từ form create vào database
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: admin/Categories/Edit/5
        //Get: lấy dữ liệu của một danh mục đã có sao cho CateID = id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
