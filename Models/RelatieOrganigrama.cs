public class RelatieOrganigrama
{
    public int Id { get; set; }
    public int Nod1Id { get; set; }
    public NodOrganigrama Nod1 { get; set; }

    public int Nod2Id { get; set; }
    public NodOrganigrama Nod2 { get; set; }

    public string NumeRelatie { get; set; }
}