using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WenShenERP.Models
{
    /// <summary>
    /// 城市
    /// </summary>
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [Display(Name="城市名称")]
        [Required(ErrorMessage="城市名称 不能为空")]
        public string CityName { set; get; }
        [Display(Name = "拼音码")]
        public string PyCode { set; get; }
        [Display(Name = "所属省份")]
        [Required(ErrorMessage = "所属省份 不能为空")]
        public int ProvinceID { set; get; }
        public virtual Province province { set; get; }
        [Display(Name = "邮编")]
        public string Postcode { set; get; }
        [Display(Name = "区号")]
        public string AreaCode { set; get; }
    }
}