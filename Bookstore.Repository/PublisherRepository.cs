using Bookstore.Models.ModelData;
using Bookstore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repository
{
    public class PublisherRepository : BaseRepository
    {
        public ListResponse<Publisher> GetPublishers(int pageIndex, int pageSize, string keyword){
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Publishers.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalReocrds = query.Count();
            List<Publisher> Publishers = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new ListResponse<Publisher>()
            {
                Results = Publishers,
                TotalRecords = totalReocrds,
            };
        }

        public Publisher GetPublisher(int id) 
        {
        return _context.Publishers.FirstOrDefault(c => c.Id == id);
         
        }


        public Publisher AddPublisher(Publisher publisher) 
        {

            var entry = _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return entry.Entity;

        }
        public Publisher UpdatePublisher(Publisher publisher)
        {

            var entry = _context.Publishers.Update(publisher);
            _context.SaveChanges();

            return entry.Entity;

        }

        public bool DeletePublisher(int id)
        {
            var category = _context.Publishers.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return false;

            _context.Publishers.Remove(category);
            _context.SaveChanges();
            return true;
        }


    }

}

