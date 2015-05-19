using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WenShenERP.Models
{
    public class DictionaryType
    {
        [Key]
        public int DictTypeID { get; set; }
        [Display(Name="分类标示")]
        [Required(ErrorMessage="分类标示 必填！")]
        public string DictTypeKey { get; set; }
        [Display(Name = "分类名称")]
        [Required(ErrorMessage = "分类名称 必填！")]
        public string DictTypeValue { get; set; }

        //明细集合
        public List<DictionaryDetails> dictDets { get; set; }
    }
}