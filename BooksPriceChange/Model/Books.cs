using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksPriceChange.Model
{
    [Table("Books")]
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
    }
}
