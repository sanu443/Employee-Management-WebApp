using System.Collections.Generic;
using PrimarieApp.Models;

public class OrganigramaInterna
{
    public int Id { get; set; }
    public string NumeOrganigrama { get; set; }
    public string MermaidCode { get; set; }

    public int? NodRootId { get; set; }
    public NodOrganigrama? NodRoot { get; set; }

    public ICollection<Departament> Departamente { get; set; }
}