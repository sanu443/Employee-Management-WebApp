using System.Collections.Generic;


namespace PrimarieApp.Models
{

    public class Post
    {
        public int Id { get; set; }
        public string NumePost { get; set; }
        public string DescrierePost { get; set; }
        public string FisaPostului { get; set; }
        public int NrAngajatiNecesari { get; set; }
        public int NrPosturiOcupate { get; set; }

        public List<Angajat> Angajati { get; set; } = new();
    }

}   