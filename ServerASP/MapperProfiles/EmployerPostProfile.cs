﻿using AutoMapper;
using ServerASP.Models;
using ServerASP.Models.DTO.Incoming;

namespace ServerASP.MapperProfiles
{
    public class EmployerPostProfile : Profile
    {
        public EmployerPostProfile()
        {
            CreateMap<EmployerPostDTO, Employer>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => 0)
                )
                .ForMember(
                    dest => dest.Firstname,
                    opt => opt.MapFrom(src => src.FirstName)
                    )
                .ForMember(
                    dest => dest.Lastname,
                    opt => opt.MapFrom(src => src.LastName)
                    )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.SurName)
                    )
                .ForMember(
                    dest => dest.isActive,
                    opt => opt.MapFrom(src => src.IsActive))
                .ForMember(
                    dest => dest.Birthday,
                    opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(
                    dest => dest.Salary,
                    opt => opt.MapFrom(src => src.Salary)
                    )
                .ForMember(
                    dest => dest.PositionId,
                    opt => opt.MapFrom(src => 0)
                    )
                .ForMember(
                    dest => dest.Position,
                    opt => opt.MapFrom(src => new Position{PositionName = src.Position})
                    );
        }
    }
}