using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.DAL.Entities;


namespace TravelBlogs.BLL.Services
{
    public class LocationService : ILocationService
    {
        private IUnitOfWork db;

        public LocationService(IUnitOfWork uow)
        {
            this.db = uow;
        }


        // Временно
        public void Create(CountryDTO countryDto)
        {
            Country country = new Country
            {
                Name = countryDto.Name,
                Description = countryDto.Description
            };
            db.Countries.Create(country);
            db.SaveAsync();
        }
    }
}
