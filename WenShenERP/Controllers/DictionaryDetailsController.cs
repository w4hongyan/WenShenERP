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
    public class DictionaryDetailsController : Controller
    {
        ERPEntities db = new ERPEntities();
        //
        // GET: /Home/

        public ActionResult Index(int? pageIndex, DictionaryDetails model)
        {
            var modelTypes = db.DictionaryTypes;
            string options = String.Empty;
            bool hasSelect = false;//是否被选中如果被选中selected=selected
            foreach(var mt in modelTypes)
            {
                if (model.DictTypeID > 0 && model.DictTypeID == mt.DictTypeID)
                {
                    options += "<option value='"+mt.DictTypeID+"'selected=selected >"+mt.DictTypeValue + "</option>";
                    hasSelect = true;
                }else
                {
                    options += "<option value='" + mt.DictTypeID + "'>" + mt.DictTypeValue + "</option>";
                }
            }
            if (hasSelect == false)
            {
                options = "<option value='0' selected=selected>不限</option>" + options;
            }else
            {
                options = "<option value='0'>不限</option>" + options;
                
            }
            ViewBag.Options = options;
            //linq语法
            var models = from m in db.DictionaryDetailses select m;
            if (model.DictTypeID > 0)
            {
                models = models.Where(m => m.DictTypeID == model.DictTypeID);
            }
            models = models.OrderBy(m => m.DictDetID);
            PagedList<DictionaryDetails> pagedList = new PagedList<DictionaryDetails>(models, pageIndex, CommonData.pagesize);
            return View(pagedList);

        }
        /// <summary>
        /// 进入创建页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            IEnumerable<DictionaryType> dTypeList = db.DictionaryTypes.ToList();
            SelectList slist = new SelectList(dTypeList, "DictTypeID", "DictTypeValue");
            ViewData["List"] = slist;
            return View();
        }
        /// <summary>
        /// 接收创建页面的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(DictionaryDetails model)
        {
            //
            if (ModelState.IsValid)
            {
                db.DictionaryDetailses.Add(model);//添加
                db.SaveChanges();//提交至数据库
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            IEnumerable<DictionaryType> dTypeList = db.DictionaryTypes.ToList();
            SelectList slist = new SelectList(dTypeList, "DictTypeID", "DictTypeValue");
            ViewData["List"] = slist;
            var model = db.DictionaryDetailses.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        /// <summary>
        /// 接收修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(DictionaryDetails model)
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
            var model = db.DictionaryDetailses.Find(id);
            if (model == null) return RedirectToAction("Index");
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var model = db.DictionaryDetailses.Find(id);
            if (model != null)
            {
                db.DictionaryDetailses.Remove(model);
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
                    var model = db.DictionaryDetailses.Find(Convert.ToInt32(id));
                    db.DictionaryDetailses.Remove(model);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
