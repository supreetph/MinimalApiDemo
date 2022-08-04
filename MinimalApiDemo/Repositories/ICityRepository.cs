using MinimalApiDemo.Models;

namespace MinimalApiDemo.Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityInformation>> GetCityInformation();
        Task<CityInformation> AddCityInfo(CityInformation cityInformation);
    }
}
