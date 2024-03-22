using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vjezba.Web.Mock
{
    public class MockClientRepository
    {
        private static List<Client> _cache;

        private static MockClientRepository _instance;
        private string _xmlPath;

        public static MockClientRepository Instance
        {
            get
            {
                return _instance ?? (_instance = new MockClientRepository());
            }
        }

        private MockClientRepository()
        {
            // Ne mijenjati.
        }

        public void Initialize(string xmlFolderPath)
        {
            this._xmlPath = Path.Combine(xmlFolderPath, "clients.xml");
        }

        public IQueryable<Client> All()
        {
            if (_cache != null)
                return _cache.AsQueryable();

            var xDoc = XDocument.Load(this._xmlPath);

            var allNodes = xDoc.Root.Descendants("client")
                .Select(p => new Client()
                {
                    ID = int.Parse(p.Descendants("id").First().Value),
                    FirstName = p.Descendants("first_name").First().Value,
                    LastName = p.Descendants("last_name").First().Value,
                    Email = p.Descendants("email").First().Value,
                    Gender = p.Descendants("gender").First().Value == "Male" ? 'M' : 'F',
                    PhoneNumber = p.Descendants("phone_number").First().Value,
                    Address = p.Descendants("address").First().Value,
                    CityID = string.IsNullOrWhiteSpace(p.Descendants("city_id").First().Value) ? null : (int?)int.Parse(p.Descendants("city_id").First().Value)
                })
                .AsQueryable()
                .ToList();

            foreach (var node in allNodes)
                node.City = MockCityRepository.Instance.FindByID(node.CityID);

            _cache = allNodes.ToList();

            return allNodes.AsQueryable();
        }

        public Client FindByID(int clientId)
        {
            return All().Where(p => p.ID == clientId)
                .FirstOrDefault();
        }

        public bool InsertOrUpdate(Client entity)
        {
            _cache.RemoveAll(p => p.ID == entity.ID);
            _cache.Add(entity);

            return true;
        }

        public bool Delete(int clientId)
        {
            _cache.RemoveAll(p => p.ID == clientId);

            return true;
        }
    }
}
