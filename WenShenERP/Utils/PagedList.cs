using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WenShenERP.Utils
{
    //首页 上一页 ... 89 90 91 92 93 94... 下一页 末页 
    public class PagedList<T>:List<T>
    {
        public int? PageIndex { get; private set; }//当前页码减1
        public int PageSize { get; private set; }//每页显示行数
        public int Start { get; private set; }//当前页面显示的第一个页号 89 90 91 92 ...
        public int End { get; private set; }//当前页面显示的最后一个页号 89 90 91 92 ...
        public int TotalPages { get; private set; }//总页数
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">列表元数据</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示数量</param>
        public PagedList(IQueryable<T> source,int? pageIndex,int pageSize) {
            PageIndex = (pageIndex ?? 0);//如果存在，赋值，不存在赋值为0
            PageSize = pageSize;
            //计算总页数=总记录数/每页显示数量 有余+1
            TotalPages = (int)Math.Ceiling(source.Count() / (double)PageSize);
            //判定每个页面显示多少页号
            int size;
            if (TotalPages > 5)
            {
                size = 5;
                //定义每个页面的页号从几开始
                if(pageIndex>2&&pageIndex<=TotalPages-(size-2))
                {
                    Start = (pageIndex ?? 0) - 1;
                }else if(pageIndex>TotalPages-(size-2))
                {
                    Start = TotalPages - size + 1;
                }
                else
                {
                    Start = 1;
                }
            }
            else {
                size = TotalPages;
                Start = 1;
            }
            End = Start + size - 1;
            //将数据分页后返回
           this.AddRange( source.Skip(PageSize * (PageIndex ?? 0)).Take(PageSize));
        }
    }
}