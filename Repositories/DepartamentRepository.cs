using System.Collections.Generic;
using System.Linq;
using PrimarieApp.Models;
using PrimarieApp.Data;
using Microsoft.EntityFrameworkCore;

namespace PrimarieApp.Repositories
{
    public interface IDepartamentRepository : IRepositoryBase<Departament>
    {
        Departament GetById(int id);
        List<Departament> GetAll();
        void Save();
    }

    public class DepartamentRepository : RepositoryBase<Departament>, IDepartamentRepository
    {
        public DepartamentRepository(PrimarieContext context) : base(context) { }

        public List<Departament> GetAll()
        {
            return FindAll().ToList();
        }

        public Departament GetById(int id)
        {
            return Context.Departamente
                .Include(d => d.Angajati)
                    .ThenInclude(a => a.Post)
                .FirstOrDefault(d => d.Id == id);
        }


        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
