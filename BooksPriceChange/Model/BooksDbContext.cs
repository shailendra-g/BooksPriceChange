using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksPriceChange.Model
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
    }
}
