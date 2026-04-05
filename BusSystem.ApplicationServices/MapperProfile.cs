using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.Core.SeatSettings;
namespace BusSystem.ApplicationServices;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SeatSetting, SeatSettingsDTO>().ReverseMap();
        CreateMap<SeatSetting, NewSeatSettingDTO>().ReverseMap();
    }
}