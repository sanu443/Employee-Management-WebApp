using PrimarieApp.Models;
using PrimarieApp.Repositories;
using System.Collections.Generic;

namespace PrimarieApp.Services
{
    public interface IAngajatService
    {
        List<Angajat> GetAll();
        Angajat GetById(int id);
        void Add(Angajat angajat);
        void Update(Angajat angajat);
        void Delete(int id);
    }

    public class AngajatService : IAngajatService
    {
        private readonly IAngajatRepository _repository;

        public AngajatService(IAngajatRepository repository)
        {
            _repository = repository;
        }

        public List<Angajat> GetAll() => _repository.GetAll();

        public Angajat GetById(int id) => _repository.GetById(id);

        public void Add(Angajat angajat)
        {
            angajat.DataAngajare = DateTime.SpecifyKind(angajat.DataAngajare, DateTimeKind.Utc);
            _repository.Create(angajat);
            _repository.Save();
        }

        public void Update(Angajat angajat)
        {
            angajat.DataAngajare = DateTime.SpecifyKind(angajat.DataAngajare, DateTimeKind.Utc);
            _repository.Update(angajat);
            _repository.Save();
        }
        public void Delete(int id)
        {
            var angajat = _repository.GetById(id);
            if (angajat != null)
            {
                _repository.Delete(angajat);
                _repository.Save();
            }
        }
    }
}
