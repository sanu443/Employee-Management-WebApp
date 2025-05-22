using System.Collections.Generic;

namespace PrimarieApp.Models
{

    public class Departament
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }

        public int? SefId { get; set; }
        public Angajat? Sef { get; set; }

        public int? OrganigramaInternaId { get; set; }
        public OrganigramaInterna? OrganigramaInterna { get; set; }

        public ICollection<Angajat> Angajati { get; set; }
    }

}