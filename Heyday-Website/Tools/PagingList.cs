using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.Tools
{
    public class PagingList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get { return PageIndex > 0; } }
        public bool HasNextPage { get { return (PageIndex + 1) < TotalPages; } }
        /// <summary>
        /// 通过构造函数向list里注入当前页的记录
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        public PagingList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            //进上去取整
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            //前端页面定义pageindex从1开始，为了统一，这里也从1开始
            this.AddRange(source.Skip((pageIndex-1) * PageSize).Take(PageSize));
        }
    }
}
