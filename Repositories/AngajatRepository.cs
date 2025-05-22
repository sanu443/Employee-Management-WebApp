using Microsoft.EntityFrameworkCore;
using PrimarieApp.Data;
using PrimarieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace PrimarieApp.Repositories
{
    public interface IAngajatRepository : IRepositoryBase<Angajat>
    {
        Angajat GetById(int id);
        List<Angajat> GetAll();
        void Save();
    }

    public class AngajatRepository : RepositoryBase<Angajat>, IAngajatRepository
    {
        public AngajatRepository(PrimarieContext context) : base(context) { }

        public List<Angajat> GetAll()
        {
            return Context.Angajati
                .Include(a => a.Post)
                .Include(a => a.Departament)
                .ToList();
        }

        public Angajat GetById(int id)
        {
            return Context.Angajati
                .Include(a => a.Post)
                .Include(a => a.Departament)
                .FirstOrDefault(a => a.Id == id);

        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
