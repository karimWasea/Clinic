﻿//using Clinic.Abstract;

//using PagedList;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Utilities
//{
//    public class PaginationHelper<T> : IPaginationHelper<T> where T : class
//    {
       

//        public IPagedList<T> Pagination<T>(IEnumerable<T> data, int pageNumber)
//        {
//            int pageSize = 10; // Set the page size to 10
//            int totalItemCount = data.Count();
//            int totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);

//            pageNumber = Math.Max(1, Math.Min(totalPages, pageNumber));

//            int startIndex = (pageNumber - 1) * pageSize;
//            int endIndex = Math.Min(startIndex + pageSize - 1, totalItemCount - 1);

//            var pagedData = data.Skip(startIndex).Take(pageSize).ToList();

//            return new StaticPagedList<T>(pagedData, pageNumber, pageSize, totalItemCount);

//        }
//    }

//}
