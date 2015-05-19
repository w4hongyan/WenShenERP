using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WenShenERP.Models
{
    public class Province
    {
        [Key]
        public int ProvinceID { get; set; }
        [Display(Name="省份名称")]
        [Required(ErrorMessage="省份名称必填！")]
        public string ProvinceName { get; set; }
        [Display(Name = "省份编码")]
        [Required(ErrorMessage = "省份编码必填！")]
        public string ProvinceCode { get; set; }
    }
}