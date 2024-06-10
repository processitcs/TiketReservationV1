using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RezervariBilete.Data;
using RezervariBilete.Models.Response;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.GetById;

public class GetRezervationByIdQueryHandler : IRequestHandler<GetRezervationByIdQuery, Response<AddEditRezervationDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetRezervationByIdQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<Response<AddEditRezervationDto>> Handle(GetRezervationByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _dbContext.Rezervares.FirstAsync(x => x.Id == request.Id);
            return new Response<AddEditRezervationDto>(_mapper.Map<AddEditRezervationDto>(response));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<AddEditRezervationDto>(null) { Succes = false, Message = e.Message };
        }
    }
}