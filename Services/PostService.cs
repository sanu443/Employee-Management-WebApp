using PrimarieApp.Models;
using PrimarieApp.Repositories;
using System.Collections.Generic;

namespace PrimarieApp.Services
{
    public interface IPostService
    {
        List<Post> GetAll();
        Post GetById(int id);
        void Add(Post post);
        void Update(Post post);
        void Delete(int id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }

        public List<Post> GetAll() => _repository.GetAll();

        public Post GetById(int id) => _repository.GetById(id);

        public void Add(Post post)
        {
            _repository.Create(post);
            _repository.Save();
        }

        public void Update(Post post)
        {
            _repository.Update(post);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var post = _repository.GetById(id);
            if (post != null)
            {
                _repository.Delete(post);
                _repository.Save();
            }
        }
    }
}
