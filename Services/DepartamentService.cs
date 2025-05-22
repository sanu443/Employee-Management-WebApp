using PrimarieApp.Models;
using PrimarieApp.Repositories;
using System.Collections.Generic;

namespace PrimarieApp.Services
{
    public interface IDepartamentService
    {
        List<Departament> GetAll();
        Departament GetById(int id);
        void Add(Departament departament);
        void Update(Departament departament);
        void Delete(int id);
    }

    public class DepartamentService : IDepartamentService
    {
        private readonly IDepartamentRepository _repository;

        public DepartamentService(IDepartamentRepository repository)
        {
            _repository = repository;
        }

        public List<Departament> GetAll() => _repository.GetAll();

        public Departament GetById(int id) => _repository.GetById(id);

        public void Add(Departament departament)
        {
            _repository.Create(departament);
            _repository.Save();
        }

        public void Update(Departament departament)
        {
            _repository.Update(departament);
            _repository.Save();
        }

        public void Delete(int id)
        {
            var departament = _repository.GetById(id);
            if (departament != null)
            {
                _repository.Delete(departament);
                _repository.Save();
            }
        }
    }
}
