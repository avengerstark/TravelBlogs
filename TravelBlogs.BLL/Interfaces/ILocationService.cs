using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TravelBlogs.BLL.DTO;
using TravelBlogs.BLL.Infrastructure;

namespace TravelBlogs.BLL.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<CountryDTO> GetAllCountries();
        IEnumerable<CountryDTO> Find(Expression<Func<CountryDTO, Boolean>> predicate);
        CountryDTO GetCountry (int id);
        void CreateCountry(CountryDTO country);
        void UpdateCountry(CountryDTO country);
        void DeleteCountry(int id);

        IEnumerable<RegionDTO> GetAllRegions();
        IEnumerable<RegionDTO> GetAllRegions(PagingInfoDTO pagingInfoDto);
        IEnumerable<RegionDTO> Find(Expression<Func<RegionDTO, Boolean>> predicate);
        IEnumerable<RegionDTO> Find(Expression<Func<RegionDTO, bool>> predicateDto, PagingInfoDTO pagingInfoDto);
        IEnumerable<RegionDTO> GetRegionsByCountry(int id);
        RegionDTO GetRegion(int id);
        void CreateRegion(RegionDTO region);
        void UpdateRegion(RegionDTO region);
        void DeleteRegion(int id);

        IEnumerable<PlaceDTO> GetAllPlaces();
        IEnumerable<PlaceDTO> GetAllPlaces(PagingInfoDTO pagingInfoDto);
        IEnumerable<PlaceDTO> Find(Expression<Func<PlaceDTO, Boolean>> predicate);
        IEnumerable<PlaceDTO> Find(Expression<Func<PlaceDTO, bool>> predicateDto, PagingInfoDTO pagingInfoDto);
        IEnumerable<PlaceDTO> GetPlacesByRegion(int id);
        PlaceDTO GetPlace(int id);
        void CreatePlace(PlaceDTO region);
        void UpdatePlace(PlaceDTO region);
        void DeletePlace(int id);
    }
}
