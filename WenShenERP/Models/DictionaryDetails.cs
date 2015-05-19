using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WenShenERP.Models
{
    public class DictionaryDetails
    {
        [Key]
        public int DictDetID { get; set; }
        [Display(Name="字典名称")]
        [Required(ErrorMessage="字典名称 必填！")]
        public string DictDetValue { set; get; }
        [Display(Name = "字典分类")]
        [Required(ErrorMessage = "字典分类 必选！")]
        public int DictTypeID { get; set; }
        public virtual DictionaryType dictType { set; get; }
    }
}