using Microsoft.EntityFrameworkCore;

namespace BookStore.Models.Repositories

{
    public class BookDBRepository : IBookStoreRepository<Book>
    {
        BookStoreDbContext dbContext;
        public BookDBRepository(BookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Book entity)
        {
            dbContext.Books.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = dbContext.Books.SingleOrDefault(x => x.IdBook == id);
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public Book Find(int id)
        {
            var book = dbContext.Books.Include(e => e.Auther).SingleOrDefault(x => x.IdBook == id);
            return book;
        }

        public IList<Book> List()
        {
            return dbContext.Books.Include(e => e.Auther).ToList();
        }

        public void Update(int id, Book newbook)
        {
            dbContext.Update(newbook);
            dbContext.SaveChanges();
        }
    }
}
