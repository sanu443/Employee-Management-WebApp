using Microsoft.EntityFrameworkCore;
using PrimarieApp.Models;

namespace PrimarieApp.Data
{
    public class PrimarieContext : DbContext
    {
        public PrimarieContext(DbContextOptions<PrimarieContext> options) : base(options) { }

        public DbSet<Angajat> Angajati { get; set; }
        public DbSet<Departament> Departamente { get; set; }
        public DbSet<Post> Posturi { get; set; }
        public DbSet<NodOrganigrama> Noduri { get; set; }
        public DbSet<RelatieOrganigrama> Relatii { get; set; }
        public DbSet<OrganigramaInterna> Organigrame { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Departament>()
                .HasOne(d => d.Sef) //are un singur sef
                .WithMany() ///tabela angajat nu o sa aiba o multime de departamente la care e sef
                .HasForeignKey(d => d.SefId) ///foreign key pentru angajat   
                .OnDelete(DeleteBehavior.Restrict); ///nu stergem un angajat daca e sef

            base.OnModelCreating(modelBuilder);
        }
    }
}
