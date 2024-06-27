using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPublisherService
    {
        public void Add(Publisher publisher);
        public void Update(Publisher publisher);
        public void Delete(Publisher publisher);
        public List<Publisher> GetAll();
        public Publisher? GetById(int id);
    }
}
