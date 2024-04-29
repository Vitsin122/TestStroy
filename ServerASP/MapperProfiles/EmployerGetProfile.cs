using AutoMapper;
using ServerASP.Models;
using ServerASP.Models.DTO.Outgoing;

namespace ServerASP.MapperProfiles
{
    public class EmployerGetProfile : Profile
    {
        public EmployerGetProfile()
        {
            CreateMap<Employer, EmployeeGetDTO>()
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.Firstname)
                    )
                .ForMember(
                    dest => dest.SurName,
                    opt => opt.MapFrom(src => src.Surname)
                    )
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.isActive)
                    )
                .ForMember(
                    dest => dest.PositionName,
                    opt => opt.MapFrom(src => src.Position!.PositionName)
                    );
            CreateMap<EmployeeGetDTO, Employer>()
                .ForMember(
                    dest => dest.Firstname,
                    opt => opt.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.SurName)
                )
                .ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(src => new Position { Id = 1, PositionName = src.PositionName })
                )
                .ForMember(
                    dest => dest.PositionId,
                    opt => opt.MapFrom(src => 1)
                )
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => 1)
                )
                .ForMember(
                    dest => dest.isActive,
                    opt => opt.MapFrom(src => src.IsActive)
                )
                .ForMember(
                    dest => dest.Salary,
                    opt => opt.MapFrom(src => 0)
                );
        }
    }
}
