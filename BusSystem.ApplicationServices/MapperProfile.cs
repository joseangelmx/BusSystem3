using AutoMapper;
using BusSystem.ApplicationServices.Shared.DTO.Buses;
using BusSystem.ApplicationServices.Shared.DTO.Places;
using BusSystem.ApplicationServices.Shared.DTO.PricingSettings;
using BusSystem.ApplicationServices.Shared.DTO.Routes;
using BusSystem.ApplicationServices.Shared.DTO.SeatSettings;
using BusSystem.ApplicationServices.Shared.DTO.Tickets;
using BusSystem.Core.Buses;
using BusSystem.Core.SeatSettings;
using BusSystem.Core.Places;
using BusSystem.Core.Routes;
using BusSystem.Core.Travels;
using BusSystem.ApplicationServices.Shared.DTO.Travels;
using BusSystem.Core.PricingSettings;
using BusSystem.Core.Tickets;

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
        
        CreateMap<Route, RouteDTO>().ReverseMap();
        CreateMap<Route, NewRouteDTO>().ReverseMap();

        CreateMap<Travel, TravelsDTO>().ReverseMap();
        CreateMap<Travel, NewTravelDTO>().ReverseMap();
        
        CreateMap<PricingSetting, PricingSettingDTO>().ReverseMap();
        CreateMap<PricingSetting, NewPricingSettingDTO>().ReverseMap();
        
        CreateMap<Ticket, NewTicketDTO>().ReverseMap();
        CreateMap<Ticket,TicketDTO>().ReverseMap();
    }
}