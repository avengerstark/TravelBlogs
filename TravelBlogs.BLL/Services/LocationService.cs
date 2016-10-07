using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.DAL.Entities;


namespace TravelBlogs.BLL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _db;

        public LocationService(IUnitOfWork uow)
        {
            this._db = uow;
        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            return Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(_db.Countries.GetAll());
        }

        public IEnumerable<CountryDTO> Find(Expression<Func<CountryDTO, Boolean>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Country, Boolean>>>(predicateDto);
            return Mapper.Map<IQueryable<Country>, IEnumerable<CountryDTO>>(_db.Countries.Find(predicate));
        }

        public CountryDTO GetCountry(int id)
        {
            return Mapper.Map<Country, CountryDTO>(_db.Countries.Get(id));
        }

        public void CreateCountry(CountryDTO countryDto)
        {
            Country country = Mapper.Map<CountryDTO, Country>(countryDto);
            _db.Countries.Create(country);
        }

        public void UpdateCountry(CountryDTO countryDto)
        {
            Country country = Mapper.Map<CountryDTO, Country>(countryDto);
            _db.Countries.Update(country);
        }

        public void DeleteCountry(int id)
        {
            _db.Countries.Delete(id);
        }





        public IEnumerable<RegionDTO> GetAllRegions()
        {
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(_db.Regions.GetAll());
        }

        public IEnumerable<RegionDTO> Find(Func<RegionDTO, bool> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Region, Boolean>>>(predicateDto);
            return Mapper.Map<IQueryable<Region>, IEnumerable<RegionDTO>>(_db.Regions.Find(predicate));
        }

        public IEnumerable<RegionDTO> GetRegionsByCountry(int id)
        {
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(_db.Regions.GetRegions(id));
        }

        public RegionDTO GetRegion(int id)
        {
            return Mapper.Map<Region, RegionDTO>(_db.Regions.Get(id));
        }

        public void CreateRegion(RegionDTO regionDto)
        {
            Region region = Mapper.Map<RegionDTO, Region>(regionDto);
            _db.Regions.Create(region);
        }

        public void UpdateRegion(RegionDTO regionDto)
        {
            Region region = Mapper.Map<RegionDTO, Region>(regionDto);
            _db.Regions.Update(region);
        }

        public void DeleteRegion(int id)
        {
            _db.Regions.Delete(id);
        }





        public IEnumerable<PlaceDTO> GetAllPlaces()
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(_db.Places.GetAll());
        }

        public IEnumerable<PlaceDTO> Find(Func<PlaceDTO, bool> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Place, bool>>>(predicateDto);
            return Mapper.Map<IQueryable<Place>, IEnumerable<PlaceDTO>>(_db.Places.Find(predicate));
        }

        public IEnumerable<PlaceDTO> GetPlacesByRegion(int id)
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(_db.Places.GetPlaces(id));
        }

        public PlaceDTO GetPlace(int id)
        {
            return Mapper.Map<Place, PlaceDTO>(_db.Places.Get(id));
        }

        public void CreatePlace(PlaceDTO placeDto)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<CoordinatesInfoDTO, CoordinatesInfo>());
            ////Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>());

            //Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>().ForMember(p => p.CoordinatesInfo
            //    , c => c.MapFrom(q => Mapper.Map<CoordinatesInfoDTO, CoordinatesInfo>(q.CoordinatesInfo))));

            //Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>()
            //    .ForMember(p => p.CoordinatesInfo, c => c.MapFrom(i => i.CoordinatesInfo)));

         
            Place place = Mapper.Map<PlaceDTO, Place>(placeDto);
            _db.Places.Create(place);
        }

        public void UpdatePlace(PlaceDTO placeDto)
        {
            Place place = Mapper.Map<PlaceDTO, Place>(placeDto);
            _db.Places.Update(place);
        }

        public void DeletePlace(int id)
        {
            _db.Places.Delete(id);
        }
      
    }
}
