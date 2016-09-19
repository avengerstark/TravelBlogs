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
            return Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(db.Countries.GetAll());
        }

        public IEnumerable<CountryDTO> FindCountries(Func<CountryDTO, bool> predicate)
        {
            IEnumerable<CountryDTO> countries = GetAllCountries();
            return countries.Where(predicate);
        }

        public CountryDTO GetCountry(int id)
        {
            return Mapper.Map<Country, CountryDTO>(db.Countries.Get(id));
        }

        public void CreateCountry(CountryDTO countryDto)
        {
            Country country = Mapper.Map<CountryDTO, Country>(countryDto);
            db.Countries.Create(country);
            db.SaveAsync();
        }

        public void UpdateCountry(CountryDTO countryDto)
        {
            Country country = Mapper.Map<CountryDTO, Country>(countryDto);
            db.Countries.Update(country);
            db.SaveAsync();
        }

        public void DeleteCountry(int id)
        {
            db.Countries.Delete(id);
            db.SaveAsync();
        }





        public IEnumerable<RegionDTO> GetAllRegions()
        {
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(db.Regions.GetAll());
        }

        public IEnumerable<RegionDTO> FindRegions(Func<RegionDTO, bool> predicate)
        {
            IEnumerable<RegionDTO> regions = GetAllRegions();
            return regions.Where(predicate);
        }

        public IEnumerable<RegionDTO> GetRegionsByCountry(int id)
        {
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(db.Regions.GetRegions(id));
        }

        public RegionDTO GetRegion(int id)
        {
            return Mapper.Map<Region, RegionDTO>(db.Regions.Get(id));
        }

        public void CreateRegion(RegionDTO regionDto)
        {
            Region region = Mapper.Map<RegionDTO, Region>(regionDto);
            db.Regions.Create(region);
            db.SaveAsync();
        }

        public void UpdateRegion(RegionDTO regionDto)
        {
            Region region = Mapper.Map<RegionDTO, Region>(regionDto);
            db.Regions.Update(region);
            db.SaveAsync();
        }

        public void DeleteRegion(int id)
        {
            db.Regions.Delete(id);
            db.SaveAsync();
        }





        public IEnumerable<PlaceDTO> GetAllPlaces()
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(db.Places.GetAll());
        }

        public IEnumerable<PlaceDTO> FindPlaces(Func<PlaceDTO, bool> predicate)
        {
            IEnumerable<PlaceDTO> places = GetAllPlaces();
            return places.Where(predicate);
        }

        public IEnumerable<PlaceDTO> GetPlacesByRegion(int id)
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(db.Places.GetPlaces(id));
        }

        public PlaceDTO GetPlace(int id)
        {
            return Mapper.Map<Place, PlaceDTO>(db.Places.Get(id));
        }

        public void CreatePlace(PlaceDTO placeDto)
        {
            Place place = Mapper.Map<PlaceDTO, Place>(placeDto);
            db.Places.Create(place);
            db.SaveAsync();
        }

        public void UpdatePlace(PlaceDTO placeDto)
        {
            Place place = Mapper.Map<PlaceDTO, Place>(placeDto);
            db.Places.Update(place);
            db.SaveAsync();
        }

        public void DeletePlace(int id)
        {
            db.Places.Delete(id);
            db.SaveAsync();
        }
    }
}
