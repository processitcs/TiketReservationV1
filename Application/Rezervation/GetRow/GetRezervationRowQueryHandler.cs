using AutoMapper;
using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RezervariBilete.Data;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Application.Rezervation.GetRow;

public class GetRezervationRowQueryHandler : IRequestHandler<GetRezervationRowQuery,IEnumerable<RezervationRowDto>>
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetRezervationRowQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<RezervationRowDto>> Handle(GetRezervationRowQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _dbContext.Rezervares.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<RezervationRowDto>>(response);
        }
        catch (Exception e)
        {
            return Enumerable.Empty<RezervationRowDto>();
        }
    }
}