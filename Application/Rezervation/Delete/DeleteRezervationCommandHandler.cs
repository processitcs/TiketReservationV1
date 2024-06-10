using AutoMapper.Configuration.Conventions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RezervariBilete.Data;
using RezervariBilete.Models.Response;

namespace RezervariBilete.Application.Rezervation.Delete;

public class DeleteRezervationCommandHandler : IRequestHandler<DeleteRezervationCommand,Response>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteRezervationCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Response> Handle(DeleteRezervationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var rezervation = await _dbContext.Rezervares.FirstAsync(x => x.Id == request.Id,cancellationToken);
            _dbContext.Remove(rezervation);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Response();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response(e.Message, false);
        }
    }
}