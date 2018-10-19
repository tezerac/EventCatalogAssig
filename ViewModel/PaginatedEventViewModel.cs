using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.ViewModel
{
    public class PaginatedEventViewModel<TEntity>
        where TEntity : class
    { 

      
            //This is a wraper
            //this is just to add these three things on the top of 
            //your data
            //private set shows only this class can set the data
            //initially we were returning un organized data with ok
            //but now we are returning data with only the view model
            public int PageIndex { get; private set; }
            public int PageSize { get; private set; }
            public long PageCount { get; private set; }


            public IEnumerable<TEntity> Data { get; set; }
            //who is gonna set this is the constructor
            public PaginatedEventViewModel(int pageIndex, int pageSize,
                long pageCount, IEnumerable<TEntity> data)
            {
                PageIndex = pageIndex;
                PageSize = pageSize;
                PageCount = pageCount;
                Data = data;
            }
     }
}


