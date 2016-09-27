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

        public IEnumerable<CountryDTO> Find(Func<CountryDTO, bool> predicateDto)
        {
            Func<Country, bool> predicate = Mapper.Map<Func<CountryDTO, bool>, Func<Country, bool>>(predicateDto);
            return Mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(db.Countries.Find(predicate));
        }

        public CountryDTO GetCountry(int id)
        {
            return Mapper.Map<Country, CountryDTO>(db.Countries.Get(id));
        }

        public void CreateCountry(CountryDTO countryDto)
        {
            Country country = Mapper.Map<CountryDTO, Country>(countryDto);
            db.Countries.Create(country);
        }

        public void UpdateCountry(CountryDTO countryDto)
        {
            Country country = Mapper.Map<CountryDTO, Country>(countryDto);
            db.Countries.Update(country);
        }

        public void DeleteCountry(int id)
        {
            db.Countries.Delete(id);
        }





        public IEnumerable<RegionDTO> GetAllRegions()
        {
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(db.Regions.GetAll());
        }

        public IEnumerable<RegionDTO> Find(Func<RegionDTO, bool> predicateDto)
        {
            Func<Region, bool> predicate = Mapper.Map<Func<RegionDTO, bool>, Func<Region, bool>>(predicateDto);
            return Mapper.Map<IEnumerable<Region>, IEnumerable<RegionDTO>>(db.Regions.Find(predicate));
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
        }

        public void UpdateRegion(RegionDTO regionDto)
        {
            Region region = Mapper.Map<RegionDTO, Region>(regionDto);
            db.Regions.Update(region);
        }

        public void DeleteRegion(int id)
        {
            db.Regions.Delete(id);
        }





        public IEnumerable<PlaceDTO> GetAllPlaces()
        {
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(db.Places.GetAll());
        }

        public IEnumerable<PlaceDTO> Find(Func<PlaceDTO, bool> predicateDto)
        {
            Func<Place, bool> predicate = Mapper.Map<Func<PlaceDTO, bool>, Func<Place, bool>>(predicateDto);
            return Mapper.Map<IEnumerable<Place>, IEnumerable<PlaceDTO>>(db.Places.Find(predicate));
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
            //Mapper.Initialize(cfg => cfg.CreateMap<CoordinatesInfoDTO, CoordinatesInfo>());
            ////Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>());

            //Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>().ForMember(p => p.CoordinatesInfo
            //    , c => c.MapFrom(q => Mapper.Map<CoordinatesInfoDTO, CoordinatesInfo>(q.CoordinatesInfo))));

            //Mapper.Initialize(cfg => cfg.CreateMap<PlaceDTO, Place>()
            //    .ForMember(p => p.CoordinatesInfo, c => c.MapFrom(i => i.CoordinatesInfo)));

         
            Place place = Mapper.Map<PlaceDTO, Place>(placeDto);
            db.Places.Create(place);
        }

        public void UpdatePlace(PlaceDTO placeDto)
        {
            Place place = Mapper.Map<PlaceDTO, Place>(placeDto);
            db.Places.Update(place);
        }

        public void DeletePlace(int id)
        {
            db.Places.Delete(id);
        }
    }
}
