using MediatR;
using RezervariBilete.Models.Response;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.GetById;

public class GetRezervationByIdQuery(Guid id) : IRequest<Response<AddEditRezervationDto>>
{
    public Guid Id { get; set; } = id;
}