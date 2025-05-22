using System;
using PrimarieApp.Models;

namespace PrimarieApp.Models
{

    public class Angajat
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public char InitialaTata { get; set; }
        public string Prenume { get; set; }
        public bool AngajatCurent { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string AdresaDomiciliu { get; set; }
        public string CNP { get; set; }
        public string ScoalaAbsolvita { get; set; }
        public float MediaConcurs { get; set; }
        public DateTime DataAngajare { get; set; }
        public float SalariuCurent { get; set; }
        public float MediaSalarii2Ani { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int DepartamentId { get; set; }
        public Departament Departament { get; set; }
    }

}