using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBlogs.DAL.Infrastructure
{
    public class PagingInfo
    {
        // номер текущей страницы
        private int _currentPage;

        // всего объектов
        public int TotalItems { get; set; }

        // кол-во объектов на странице
        public int PageSize { get; set; }

        // номер текущей страницы
        public int CurrentPage 
        {
            get
            {
                if (_currentPage > TotalPages)
                {
                    return TotalPages;
                }
                return _currentPage;
            }
            set { _currentPage = value; } 
        }

        // всего страниц
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
