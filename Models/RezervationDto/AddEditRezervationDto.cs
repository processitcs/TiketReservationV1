using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RezervariBilete.Models.RezervationDto;

public class AddEditRezervationDto
{
    public Guid? Id { get; set; }
    [DisplayName("Nume")]
    public string FirstName { get; set; } = string.Empty;
    [DisplayName("Prenume")]

    public string LastName { get; set; } = string.Empty;
    [DisplayName("Denumire eveniment")]

    public string EventName { get; set; } = string.Empty;
    [DisplayName("Numarul de bilete")]

    public int TiketNumber { get; set; } 
    [DisplayName("Data Rezerverii")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime EventDate { get; set; }
    [DisplayName("Tipul Biletului")]

    public int TiketType { get; set; }
}