using System;

namespace TravelBlogs.BLL.Infrastructure
{
    public class PagingInfoDTO
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
