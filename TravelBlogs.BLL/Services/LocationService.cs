using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Linq.Expressions;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.DAL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;
using TravelBlogs.DAL.Entities;
using TravelBlogs.DAL.Infrastructure;


namespace TravelBlogs.BLL.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _db;
        private readonly ICacheService _cacheService;

        public LocationService(IUnitOfWork uow)
        {
            _db = uow;
            _cacheService = new InMemoryCache();
        }

        public IEnumerable<CountryDTO> GetAllCountries()
        {
            return _cacheService.GetOrSet("GetAllCountries",
                () => Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(_db.Countries.GetAll()));
        }

        

        public IEnumerable<CountryDTO> Find(Expression<Func<CountryDTO, Boolean>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Country, Boolean>>>(predicateDto);
            return _cacheService.GetOrSet(String.Format("FindCountry{0}", predicate),
                () => Mapper.Map<IQueryable<Country>, IEnumerable<CountryDTO>>(_db.Countries.Find(predicate)));
        }

        public CountryDTO GetCountry(int id)
        {
            return _cacheService.GetOrSet(String.Format("GetCountry{0}", id),
                () => Mapper.Map<Country, CountryDTO>(_db.Countries.Get(id)));
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
            return _cacheService.GetOrSet("GetAllRegions",
                () => Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(_db.Regions.GetAll()));
        }

        public IEnumerable<RegionDTO> GetAllRegions(PagingInfoDTO pagingInfoDto)
        {
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(String.Format("GetAllRegions{0}{1}", pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(_db.Regions.GetAll(pagingInfo)));
        }

        public IEnumerable<RegionDTO> Find(Expression<Func<RegionDTO, bool>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Region, Boolean>>>(predicateDto);
            return _cacheService.GetOrSet(String.Format("FindRegions{0}", predicate),
                () => Mapper.Map<IQueryable<Region>, IEnumerable<RegionDTO>>(_db.Regions.Find(predicate)));
        }

        public IEnumerable<RegionDTO> Find(Expression<Func<RegionDTO, bool>> predicateDto, PagingInfoDTO pagingInfoDto)
        {
            var predicate = Mapper.Map<Expression<Func<Region, Boolean>>>(predicateDto);
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("FindRegions{0}{1}{2}", predicate, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IQueryable<Region>, IEnumerable<RegionDTO>>(_db.Regions.Find(predicate, pagingInfo)));
        }

        public IEnumerable<RegionDTO> GetRegionsByCountry(int id)
        {
            Expression<Func<Region, bool>> predicate = region => region.CountryId == id;
            return _cacheService.GetOrSet(String.Format("GetRegionsByCountry{0}", id),
                () => Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(_db.Regions.Find(predicate)));
        }

        public IEnumerable<RegionDTO> GetRegionsByCountry(int id, PagingInfoDTO pagingInfoDto)
        {
            Expression<Func<Region, bool>> predicate = region => region.CountryId == id;
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("GetRegionsByCountry{0}{1}{2}", id, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(_db.Regions.Find(predicate, pagingInfo)));
        }

        public RegionDTO GetRegion(int id)
        {
            return _cacheService.GetOrSet(String.Format("GetRegion{0}", id),
                () => Mapper.Map<Region, RegionDTO>(_db.Regions.Get(id)));
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
            return _cacheService.GetOrSet("GetAllPlaces",
                () => Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(_db.Places.GetAll()));
        }

        public IEnumerable<PlaceDTO> GetAllPlaces(PagingInfoDTO pagingInfoDto)
        {
            
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(String.Format("GetAllPlaces{0}{1}", pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(_db.Places.GetAll(pagingInfo)));
        }

        public IEnumerable<PlaceDTO> Find(Expression<Func<PlaceDTO, bool>> predicateDto)
        {
            var predicate = Mapper.Map<Expression<Func<Place, bool>>>(predicateDto);
            return _cacheService.GetOrSet(String.Format("FindPlaces{0}", predicate),
                () => Mapper.Map<IQueryable<Place>, IEnumerable<PlaceDTO>>(_db.Places.Find(predicate)));
        }

        public IEnumerable<PlaceDTO> Find(Expression<Func<PlaceDTO, bool>> predicateDto, PagingInfoDTO pagingInfoDto)
        {
            var predicate = Mapper.Map<Expression<Func<Place, bool>>>(predicateDto);
            PagingInfo pagingInfo = Mapper.Map<PagingInfo>(pagingInfoDto);
            return _cacheService.GetOrSet(
                String.Format("FindPlaces{0}{1}{2}", predicate, pagingInfo.CurrentPage, pagingInfo.PageSize),
                () => Mapper.Map<IQueryable<Place>, IEnumerable<PlaceDTO>>(_db.Places.Find(predicate, pagingInfo)));
        }

        public IEnumerable<PlaceDTO> GetPlacesByRegion(int id)
        {
            Expression<Func<Place, bool>> predicate = place => place.RegionId == id;
            return _cacheService.GetOrSet(String.Format("GetPlacesByRegion{0}", id),
                () => Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(_db.Places.Find(predicate)));
        }

        public PlaceDTO GetPlace(int id)
        {
            return _cacheService.GetOrSet(String.Format("GetPlace{0}", id),
                () => Mapper.Map<Place, PlaceDTO>(_db.Places.Get(id)));
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
