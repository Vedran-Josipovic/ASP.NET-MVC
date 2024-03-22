using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vjezba.Web.Mock
{
    public class MockCityRepository
    {
        private static List<City> _cache;

        private static MockCityRepository _instance;
        private string _xmlPath;

        public static MockCityRepository Instance
        {
            get
            {
                return _instance ?? (_instance = new MockCityRepository());
            }
        }

        public void Initialize(string xmlFolderPath)
        {
            this._xmlPath = Path.Combine(xmlFolderPath, "cities.xml");
        }

        private MockCityRepository()
        {
            // Ne mijenjati.
        }

        public IQueryable<City> All()
        {
            if (_cache != null)
                return _cache.AsQueryable();

            var xDoc = XDocument.Load(this._xmlPath);

            var allNodes = xDoc.Root.Descendants("city")
                .Select(p => new City()
                {
                    ID = int.Parse(p.Descendants("id").First().Value),
                    Name = p.Descendants("name").First().Value,
                })
                .AsQueryable();

            _cache = allNodes.ToList();

            return allNodes;
        }

        public City FindByID(int? cityId)
        {
            return All().Where(p => p.ID == cityId)
                .FirstOrDefault();
        }

        public bool InsertOrUpdate(City entity)
        {
            //This is just mock repository
            return true;
        }

        public bool Delete(int cityId)
        {
            //This is just mock repository
            return true;
        }
    }
}
