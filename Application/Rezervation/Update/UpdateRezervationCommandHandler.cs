using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RezervariBilete.Data;
using RezervariBilete.Models.Response;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.Update;

public class UpdateRezervationCommandHandler : IRequestHandler<UpdateRezervationCommand, Response>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateRezervationCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateRezervationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _dbContext.Rezervares
                .FirstAsync(x => x.Id == request.Model.Id.Value);
            _mapper.Map(request.Model, response);
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