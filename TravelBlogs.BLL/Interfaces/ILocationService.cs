using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.BLL.DTO;

namespace TravelBlogs.BLL.Interfaces
{
    public interface ILocationService
    {
        void Create(CountryDTO country);
    }
}
