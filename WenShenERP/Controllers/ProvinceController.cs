using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WenShenERP.Models;
using WenShenERP.Utils;

namespace WenShenERP.Controllers
{
    public class ProvinceController : Controller
    {
        ERPEntities db = new ERPEntities();
        //
        // GET: /Home/

        public ActionResult Index(int? pageIndex,Province model)
        {
            //linq语法
            var models = from m in db.Provinces select m;
            if (!string.IsNullOrEmpty(model.ProvinceName)) {
                //相当于like查询
                models = models.Where(m => m.ProvinceName.Contains(model.ProvinceName));
            }
            ViewBag.ProvinceName = model.ProvinceName;
            models= models.OrderBy(m => m.ProvinceID);
            PagedList<Province> pagedList = new PagedList<Province>(models, pageIndex, CommonData.pagesize);
            return View(pagedList);
            
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
