using BusinessObjects;
using Repositories;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepo _repository;

        public PublisherService(IPublisherRepo repository)
        {
            _repository = repository;
        }

        public void Add(Publisher publisher)
            => _repository.Add(publisher);

        public void Delete(Publisher publisher)
            => _repository.Delete(publisher);

        public List<Publisher> GetAll()
            => _repository.GetAll();

        public Publisher? GetById(int id)
            => _repository.GetById(id);

        public void Update(Publisher publisher)
            => _repository.Update(publisher);
    }
}

