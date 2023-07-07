using AutoMapper;
using CorretoraAPI.Models;
using CorretoraAPI.Models.Dto.House;
using CorretoraAPI.Models.Dto.Operation;


namespace CorretoraAPI.Helpers
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<House, HouseDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.Agent, opt => opt.MapFrom(src => src.Agent))
            .ForMember(dest => dest.Operations, opt => opt.MapFrom(src => src.Operations))
            .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.updated_at, opt => opt.MapFrom(src => src.UpdateAt));

            CreateMap<Customer, CustomerDto>()
           .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Agent, AgentDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Operation, OperationDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.buyer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.seller, opt => opt.MapFrom(src => src.Agent))
            .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<House, HouseListDto>()
            .ForMember(dest => dest.Agent, opt => opt.MapFrom(src => src.Agent))
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Operation, OperationListDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.house, opt => opt.MapFrom(src => src.House))
            .ForMember(dest => dest.buyer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.seller, opt => opt.MapFrom(src => src.Agent))
            .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}