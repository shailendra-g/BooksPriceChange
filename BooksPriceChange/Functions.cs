using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace BooksPriceChange
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        //public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log)
        //{
        //    log.WriteLine(message);
        //}

        public static void CheckForPublishedDateToReducePrice(TextWriter log)
        {
            bool itemsRemoved = false;

            log.WriteLine("Checking for books published more than 10 years ago that can be discounted");

            var ctx = new Model.BooksDbContext();
            ctx.Database.Connection.ConnectionString = "data source=shailendrasqldb.database.windows.net;initial catalog=AdventureWorks2017;User ID=shailendra.g;Password=Chotu@143;MultipleActiveResultSets=True;App=EntityFramework";
            var expdate = DateTime.Now.AddYears(-10);
            var query = from book in ctx.Books
                        where book.PublishDate < expdate
                        select book;

            foreach (var item in query)
            {
                itemsRemoved = true;
                item.Price = item.Price > 15 ?  (item.Price * 90) / 100 : item.Price;                
            }

            if (itemsRemoved)
            {
                ctx.SaveChanges();
            }

        }
    }
}
