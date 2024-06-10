using Azure;
using MediatR;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.GetRow;

public class GetRezervationRowQuery : IRequest<IEnumerable<RezervationRowDto>>
{
    
}