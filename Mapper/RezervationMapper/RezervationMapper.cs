using AutoMapper;
using RezervariBilete.Data.Entity;
using RezervariBilete.Models.RezervationDto;

namespace RezervariBilete.Mapper.RezervationMapper;

public class RezervationMapper : Profile
{
    public RezervationMapper()
    {
        CreateMap<Rezervare,RezervationRowDto>();
        CreateMap<AddEditRezervationDto,Rezervare>()
            .ForMember(dest=>dest.Type,opt=>opt.MapFrom(src=>src.TiketType))
            .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.FirstName))
            .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.LastName))
            .ForMember(dest=>dest.EventName,opt=>opt.MapFrom(src=>src.EventName))
            .ForMember(dest=>dest.NrBilete,opt=>opt.MapFrom(src=>src.TiketNumber))
            .ForMember(dest=>dest.ReservationTime,opt=>opt.MapFrom(src=>src.EventDate))
            .ReverseMap()
            .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest=>dest.TiketType,opt=>opt.MapFrom(src=>src.Type))
            .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(src=>src.Name))
            .ForMember(dest=>dest.LastName,opt=>opt.MapFrom(src=>src.UserName))
            .ForMember(dest=>dest.EventName,opt=>opt.MapFrom(src=>src.EventName))
            .ForMember(dest=>dest.TiketType,opt=>opt.MapFrom(src=>src.NrBilete))
            .ForMember(dest=>dest.EventDate,opt=>opt.MapFrom(src=>src.ReservationTime))

            ;
        ;
    }
}