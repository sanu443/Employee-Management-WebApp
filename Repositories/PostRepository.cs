using Microsoft.EntityFrameworkCore;
using PrimarieApp.Data;
using PrimarieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PrimarieApp.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        Post GetById(int id);
        List<Post> GetAll();
        void Save();
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(PrimarieContext context) : base(context) { }

        public List<Post> GetAll()
        {
            return FindAll().ToList();
        }

        public Post GetById(int id)
        {
            return Context.Posturi
                .Include(p => p.Angajati)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
