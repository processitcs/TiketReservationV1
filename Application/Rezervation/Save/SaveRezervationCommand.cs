using MediatR;
using RezervariBilete.Models.Response;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.Save;

public class SaveRezervationCommand(AddEditRezervationDto model) : IRequest<Response>
{
    public AddEditRezervationDto Model { get; set; } = model;
}