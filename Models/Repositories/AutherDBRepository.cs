namespace BookStore.Models.Repositories
{
    public class AutherDBRepository : IBookStoreRepository<Auther>
    {
        BookStoreDbContext dbContext;
        public AutherDBRepository(BookStoreDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(Auther entity)
        {
            dbContext.Authers.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var auther = Find(id);
            dbContext.Authers.Remove(auther);
            dbContext.SaveChanges();
        }

        public Auther Find(int id)
        {
            var auther = dbContext.Authers.SingleOrDefault(x => x.IdAuther == id);
            return auther;
        }

        public IList<Auther> List()
        {
            return dbContext.Authers.ToList();
        }

        public void Update(int id, Auther newauther)
        {
            dbContext.Update(newauther);
            dbContext.SaveChanges();
        }
    }
}