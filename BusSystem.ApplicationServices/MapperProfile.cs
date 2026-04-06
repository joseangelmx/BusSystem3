using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Buses;
using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.Core.Buses;
using BusSystem.Core.SeatSettings;
using BusSystem.Core.Places;
namespace BusSystem.ApplicationServices;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SeatSetting, SeatSettingsDTO>().ReverseMap();
        CreateMap<SeatSetting, NewSeatSettingDTO>().ReverseMap();
        
        CreateMap<Bus, BusDTO>().ReverseMap();
        CreateMap<Bus, NewBusDTO>().ReverseMap();
        
        CreateMap<Place, PlaceDTO>().ReverseMap();
        CreateMap<Place, NewPlaceDTO>().ReverseMap();
    }
}