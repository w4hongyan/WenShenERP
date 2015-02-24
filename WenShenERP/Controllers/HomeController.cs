using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenShenERP.Models;

namespace WenShenERP.Controllers
{
    public class HomeController : Controller
    {
        ERPEntities db = new ERPEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //linq语法
            var models = from m in db.Provinces select m;
            return View(models.ToList());
        }
        /// <summary>
        /// 进入创建页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 接收创建页面的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Province model)
        {
            //
            if(ModelState.IsValid)
            {
                db.Provinces.Add(model);//添加
                db.SaveChanges();//提交至数据库
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.Provinces.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        /// <summary>
        /// 接收修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Province model)
        {
            if (ModelState.IsValid)
            { 
            //把存储状态修改成“modified”
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// 显示详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = db.Provinces.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Provinces.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            var model = db.Provinces.Find(id);
            if (model != null) 
            {
                db.Provinces.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
