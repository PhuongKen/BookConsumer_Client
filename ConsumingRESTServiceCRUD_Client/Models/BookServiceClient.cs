
using ConsumingRESTServiceCRUD_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsumingRESTServiceCRUD_Client.Models
{
    public class BookServiceClient
    {
        BookServicesClient client = new BookServicesClient();

        //////string BASE_URL = "http://localhost:50959/BookService.svc";

        public Book Find(int? id)
        {
            var find = client.GetBookById(Convert.ToString(id));
            Book book = new Book();

            book.BookId = find.BookId;
            book.ISBN = find.ISBN;
            book.Title = find.Title;

            return book;
        }

        public List<Book> getAllBook()
        {
            var list = client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book()
            {
                BookId = b.BookId,
                ISBN = b.ISBN,
                Title = b.Title
            }));

            return rt;

            //var syncClient = new WebClient();
            //var content = syncClient.DownloadString(BASE_URL + "Books");
            //var json_serializer = new JavaScriptSerializer();

            //return json_serializer.Deserialize<List<Book>>(content);
        }
        
        public string AddBook(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };

            return client.AddBook(book);
        }

        public string DeleteBook(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }

        public string Edit(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };

            return client.UpdateBook(book);
        }
    }
}