using MinimalApiDemo.Models;
using MongoDB.Driver;

namespace MinimalApiDemo.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IMongoCollection<CityInformation> _mongoCollection;

        public CityRepository(IMongoDatabase mongoDatabase)
        {
            _mongoCollection = mongoDatabase.GetCollection<CityInformation>("CityInformation");
        }

        public async Task<CityInformation> AddCityInfo(CityInformation cityInformation)
        {
             await _mongoCollection.InsertOneAsync(cityInformation);
            return cityInformation;
        }

        public async  Task<IEnumerable<CityInformation>> GetCityInformation()
        {
            return await _mongoCollection.Find(_ => true).ToListAsync();
        }
    }

       
    }

