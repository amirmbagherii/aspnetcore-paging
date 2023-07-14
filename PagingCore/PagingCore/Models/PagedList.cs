using System;
using System.Collections.Generic;
using System.Text;

namespace PagingCore.Models
{
    public class PagedList<TSource>
    {
        public List<TSource> Items { get; set; } = new List<TSource>();
        public long Total { get; internal set; } = 0;
        public int CurrentPage { get; internal set; } = 1;
        public int TotalPages { get; set; } = 0;
        public int ItemsPerPage { get; set; } = 15;
    }
}
