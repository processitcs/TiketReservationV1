using RezervariBilete.Models.Enum;

namespace RezervariBilete.Models.RezervationDto;

public class RezervationRowDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public DateTime ReservationTime { get; set; }
    public int NrBilete { get; set; }
    public string EventName { get; set; }
    public BiletType Type { get; set; }
}