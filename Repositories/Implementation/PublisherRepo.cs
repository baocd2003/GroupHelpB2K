using BusinessObjects;
using DataAccessObjects;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class PublisherRepo : IPublisherRepo
    {
        private readonly IGenericDAO<Publisher> _dao;
        public PublisherRepo(IGenericDAO<Publisher> dao)
        {
            _dao = dao;
        }

        public void Add(Publisher publisher)
            => _dao.Add(publisher);

        public void Delete(Publisher publisher)
            => _dao.Delete(publisher);

        public List<Publisher> GetAll()
            => _dao.Query().ToList();

        public Publisher? GetById(int id)
            => _dao.GetById(id);

        public void Update(Publisher publisher)
            => _dao.Update(publisher);
    }
}
