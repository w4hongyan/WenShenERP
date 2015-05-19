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
    public class CityController : Controller
    {
        ERPEntities db = new ERPEntities();
        //
        // GET: /Home/

        public ActionResult Index(int? pageIndex, City model)
        {
            //linq语法
            var models = from m in db.Citys select m;
            if (!string.IsNullOrEmpty(model.CityName))
            {
                //相当于like查询
                models = models.Where(m => m.CityName.Contains(model.CityName));
            }
            if(model.ProvinceID>0)
            {
                models = models.Where(m => m.ProvinceID == model.ProvinceID);
            }
            ViewBag.CityName = model.CityName;
            var provinces = from p in db.Provinces select p;
            string str = "<option value='-1'>不限</option>";
            foreach (Province p in provinces) {
                if (model.ProvinceID == p.ProvinceID)
                {
                    str += "<option value='" + p.ProvinceID + "' selected='selected'>" + p.ProvinceName + "</option>";
                }
                else
                {
                    str += "<option value='" + p.ProvinceID + "'>" + p.ProvinceName + "</option>";
                }
            }
            ViewBag.prolist = str;
            models = models.OrderBy(m => m.CityID);
            PagedList<City> pagedList = new PagedList<City>(models, pageIndex, CommonData.pagesize);
            return View(pagedList);

        }
        /// <summary>
        /// 进入创建页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            IEnumerable<Province> prolist = (from m in db.Provinces select m).ToList();
            SelectList slist = new SelectList(prolist, "ProvinceID", "ProvinceName");
            ViewData["List"] = slist;
            return View();
        }
        /// <summary>
        /// 接收创建页面的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(City model)
        {
            //
            if (ModelState.IsValid)
            {
                db.Citys.Add(model);//添加
                db.SaveChanges();//提交至数据库
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.Citys.Find(id);
            if (model == null) return RedirectToAction("Index");
            IEnumerable<Province> prolist = (from m in db.Provinces select m).ToList();
            SelectList slist = new SelectList(prolist, "ProvinceID", "ProvinceName",model.ProvinceID);
            ViewData["List"] = slist;
            return View(model);
        }
        /// <summary>
        /// 接收修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(City model)
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
            var model = db.Citys.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var model = db.Citys.Find(id);
            if (model != null)
            {
                db.Citys.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
