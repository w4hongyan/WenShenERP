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
    public class DictionaryTypeController : Controller
    {
        ERPEntities db = new ERPEntities();
        //
        // GET: /Home/

        public ActionResult Index(int? pageIndex, DictionaryType model)
        {
            //linq语法
            var models = from m in db.DictionaryTypes select m;
            models = models.OrderBy(m => m.DictTypeID);
            PagedList<DictionaryType> pagedList = new PagedList<DictionaryType>(models, pageIndex, CommonData.pagesize);
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
        public ActionResult Create(DictionaryType model)
        {
            //
            if (ModelState.IsValid)
            {
                db.DictionaryTypes.Add(model);//添加
                db.SaveChanges();//提交至数据库
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.DictionaryTypes.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        /// <summary>
        /// 接收修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(DictionaryType model)
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
            var model = db.DictionaryTypes.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var model = db.DictionaryTypes.Find(id);
            if (model != null)
            {
                db.DictionaryTypes.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteAll(string idstr)
        {
            string[] ids = idstr.Split(new char[] { ',' });
            foreach (string id in ids)
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var model = db.DictionaryTypes.Find(Convert.ToInt32(id));
                    db.DictionaryTypes.Remove(model);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
