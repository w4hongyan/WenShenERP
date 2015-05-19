using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WenShenERP.Models
{
    public class InitData:DropCreateDatabaseIfModelChanges<ERPEntities>
    {
        protected override void Seed(ERPEntities context)
        {
            var l_povinces = new List<Province>{
            new Province{ProvinceName="北京市",ProvinceCode="bjs"},
            new Province{ProvinceName="上海市",ProvinceCode="shs"},
            new Province{ProvinceName="天津市",ProvinceCode="tjs"},
            new Province{ProvinceName="重庆市",ProvinceCode="cqs"},
            new Province{ProvinceName="安徽省",ProvinceCode="ahs"},
            new Province{ProvinceName="福建省",ProvinceCode="fjs"},
            new Province{ProvinceName="甘肃省",ProvinceCode="gss"},
            new Province{ProvinceName="广东省",ProvinceCode="gds"},
            new Province{ProvinceName="广西",ProvinceCode="gx"},
            new Province{ProvinceName="贵州省",ProvinceCode="gzs"},
            new Province{ProvinceName="河北省",ProvinceCode="hbs"},
            new Province{ProvinceName="河南省",ProvinceCode="hns"},
            new Province{ProvinceName="黑龙江省",ProvinceCode="hljs"},
            new Province{ProvinceName="湖北省",ProvinceCode="hbs"},
            new Province{ProvinceName="湖南省",ProvinceCode="hns"},
            new Province{ProvinceName="吉林省",ProvinceCode="jls"},
            new Province{ProvinceName="江苏省",ProvinceCode="jss"},
            new Province{ProvinceName="江西省",ProvinceCode="jxs"},
            new Province{ProvinceName="辽宁省",ProvinceCode="lns"},
            new Province{ProvinceName="内蒙古",ProvinceCode="nmg"},
            new Province{ProvinceName="宁夏",ProvinceCode="nx"},
            new Province{ProvinceName="青海省",ProvinceCode="qhs"},
            new Province{ProvinceName="山东省",ProvinceCode="sds"},
            new Province{ProvinceName="山西省",ProvinceCode="sxs"},
            new Province{ProvinceName="陕西省",ProvinceCode="sxs"},
            new Province{ProvinceName="四川省",ProvinceCode="scs"},
            new Province{ProvinceName="西藏",ProvinceCode="xz"},
            new Province{ProvinceName="新疆",ProvinceCode="xj"},
            new Province{ProvinceName="云南省",ProvinceCode="yns"},
            new Province{ProvinceName="浙江省",ProvinceCode="zjs"},
            new Province{ProvinceName="海南省",ProvinceCode="hls"},
            new Province{ProvinceName="香港",ProvinceCode="xg"},
            new Province{ProvinceName="台湾省",ProvinceCode="tys"}
            };
            l_povinces.ForEach(m=>context.Provinces.Add(m));
            context.SaveChanges();
            var l_cities = new CityData().GetCities(l_povinces);
            l_cities.ForEach(p => context.Citys.Add(p));
        }
    }
}