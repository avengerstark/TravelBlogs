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





        public IEnumerable<CountryDTO> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CountryDTO> FindCountries(Func<CountryDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public CountryDTO GetCountry(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateCountry(CountryDTO countryDto)
        {
            Country country = new Country
            {
                Name = countryDto.Name,
                Description = countryDto.Description
            };
            db.Countries.Create(country);
            db.SaveAsync();
        }




        public void UpdateCountry(CountryDTO country)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegionDTO> GetAllRegions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegionDTO> FindRegions(Func<RegionDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegionDTO> GetRegionsByCountry(int id)
        {
            throw new NotImplementedException();
        }

        public RegionDTO GetRegion(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateRiogion(RegionDTO region)
        {
            throw new NotImplementedException();
        }

        public void UpdateRegion(RegionDTO region)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegion(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceDTO> GetAllPlaces()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceDTO> FindPlaces(Func<PlaceDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceDTO> GetPlacesByRegion(int id)
        {
            throw new NotImplementedException();
        }

        public PlaceDTO GetPlace(int id)
        {
            throw new NotImplementedException();
        }

        public void CreatePlace(PlaceDTO region)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlace(PlaceDTO region)
        {
            throw new NotImplementedException();
        }

        public void DeletePlace(int id)
        {
            throw new NotImplementedException();
        }
    }
}
