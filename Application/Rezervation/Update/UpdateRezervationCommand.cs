using MediatR;
using RezervariBilete.Models.Response;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.Update;

public class UpdateRezervationCommand(AddEditRezervationDto model) : IRequest<Response>
{
    public AddEditRezervationDto Model { get; set; } = model;
}