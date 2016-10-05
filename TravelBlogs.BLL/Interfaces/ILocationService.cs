using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using TravelBlogs.BLL.DTO;

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
        IEnumerable<RegionDTO> Find(Func<RegionDTO, Boolean> predicate);
        IEnumerable<RegionDTO> GetRegionsByCountry(int id);
        RegionDTO GetRegion(int id);
        void CreateRegion(RegionDTO region);
        void UpdateRegion(RegionDTO region);
        void DeleteRegion(int id);

        IEnumerable<PlaceDTO> GetAllPlaces();
        IEnumerable<PlaceDTO> Find(Func<PlaceDTO, Boolean> predicate);
        IEnumerable<PlaceDTO> GetPlacesByRegion(int id);
        PlaceDTO GetPlace(int id);
        void CreatePlace(PlaceDTO region);
        void UpdatePlace(PlaceDTO region);
        void DeletePlace(int id);
    }
}
