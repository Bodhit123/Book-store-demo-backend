using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models.ModelData;

namespace Bookstore.Repository
{
    public class BaseRepository
    {
        protected readonly BookstoreContext _context = new BookstoreContext();
    }
}
