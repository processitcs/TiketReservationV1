using MediatR;
using RezervariBilete.Models.Response;

namespace RezervariBilete.Application.Rezervation.Delete;

public class DeleteRezervationCommand(Guid id) : IRequest<Response>
{
    public Guid Id { get; set; } = id;
}