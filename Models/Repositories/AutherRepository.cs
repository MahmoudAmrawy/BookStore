using System.Linq;

namespace BookStore.Models.Repositories
{
    public class AutherRepository : IBookStoreRepository<Auther>
    {
        List<Auther> authers;
        public AutherRepository()
        {
            authers = new List<Auther>()
            {
                new Auther{IdAuther=1, NameAuther="mahmoud"},
                new Auther{IdAuther=2, NameAuther="mona"},
                new Auther{IdAuther=3, NameAuther="nada"},
                new Auther{IdAuther=4, NameAuther="ahmed"}
            };
        }
        public void Add(Auther entity)
        {
            entity.IdAuther = authers.Max(x => x.IdAuther) + 1;
            authers.Add(entity);
        }

        public void Delete(int id)
        {
            var auther = Find(id);
            authers.Remove(auther);
        }

        public Auther Find(int id)
        {
            var auther = authers.SingleOrDefault(x => x.IdAuther == id);
            return auther;
        }

        public IList<Auther> List()
        {
            return authers;
        }

        public void Update(int id, Auther newauther)
        {
            var auther = Find(id);
            auther.NameAuther = newauther.NameAuther;
        }
    }
}
