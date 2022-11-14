using AutoMapper;
using ReyMagoAPI.Core.Models.DTO;
using ReyMagoAPI.Entities;

namespace ReyMagoApi.Core.Mapper;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        
        CreateMap<SolicitudIngreso, SolicitudIngresoDTO>().ReverseMap();
        CreateMap<SolicitudIngreso, SolicitudIngresoPorGrimorioDTO>().ReverseMap();

    }
}