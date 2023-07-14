using PagingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagingCore.Extensions
{
    public static class Paging
    {
        public static PagedList<TSource> ToPagedList<TSource>(this List<TSource> source, 
            int currentPage = 1,
            int itemsPerPage = 15)
        {
            int skip = (currentPage - 1) * itemsPerPage;
            PagedList<TSource> result = new PagedList<TSource>();
            result.Items = source.Skip(skip).Take(itemsPerPage).ToList();
            result.Total = source.LongCount();
            result.CurrentPage = currentPage;
            result.TotalPages = (int)Math.Ceiling((double)result.Total / (double)itemsPerPage);
            result.ItemsPerPage = itemsPerPage;

            return result;
        }

        public static PagedList<TSource> NextPage<TSource>(this PagedList<TSource> source,
            int itemsPerPage = 15)
        {
            source.CurrentPage += 1;
            int skip = (source.CurrentPage - 1) * itemsPerPage;

            source.Items = source.Items.Skip(skip).Take(itemsPerPage).ToList();
            source.ItemsPerPage = itemsPerPage;

            return source;
        }

        public static PagedList<TSource> PreviousPage<TSource>(this PagedList<TSource> source,
            int itemsPerPage = 15)
        {
            source.CurrentPage -= 1;
            int skip = (source.CurrentPage - 1) * itemsPerPage;

            source.Items = source.Items.Skip(skip).Take(itemsPerPage).ToList();
            source.ItemsPerPage = itemsPerPage;

            return source;
        }
    }
}
