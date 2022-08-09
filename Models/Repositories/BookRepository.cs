namespace BookStore.Models.Repositories
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    IdBook=1, 
                    Title="Paython", 
                    Description="No Description",
                    ImgUrl = "paython.png",
                    Auther= new Auther{IdAuther=1, NameAuther="mahmoud"} 
                },
                new Book
                {
                    IdBook=2, 
                    Title="Javascript", 
                    Description="No Description",
                    ImgUrl = "java.jpg",
                    Auther= new Auther{IdAuther=2, NameAuther="mona"}
                },
                new Book
                {
                    IdBook=3, 
                    Title="EntityFramework", 
                    Description="No Description",
                    ImgUrl = "html.png",
                    Auther= new Auther{IdAuther=3, NameAuther="nada"}
                },
                new Book
                {
                    IdBook=4, 
                    Title="Programing", 
                    Description="No Description",
                    ImgUrl = "csharp.png",
                    Auther= new Auther{IdAuther=4, NameAuther="ahmed"}
                }
            };
        }
        public void Add(Book entity)
        {
            entity.IdBook = books.Max(b => b.IdBook) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = books.SingleOrDefault(x => x.IdBook == id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(x => x.IdBook == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book newbook)
        {
            var book = books.SingleOrDefault(x => x.IdBook == id);
            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Auther.NameAuther = newbook.Auther.NameAuther;
            book.ImgUrl = newbook.ImgUrl;
        }
    }
}
