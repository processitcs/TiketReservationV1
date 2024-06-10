using AutoMapper;
using MediatR;
using RezervariBilete.Data;
using RezervariBilete.Data.Entity;
using RezervariBilete.Models.Response;

namespace RezervariBilete.Application.Rezervation.Save;

public class SaveRezervationCommandHandler : IRequestHandler<SaveRezervationCommand,Response>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public SaveRezervationCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<Response> Handle(SaveRezervationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _dbContext.Rezervares.Add(_mapper.Map<Rezervare>(request.Model));
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new Response("Rezervarea a fost adaugata cu succes",true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response(e.Message, false);
        }
    }
}