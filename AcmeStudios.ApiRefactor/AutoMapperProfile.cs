using AcmeStudios.ApiRefactor.DAL.Entities;
using AcmeStudios.ApiRefactor.DAL.Repository;
using AcmeStudios.ApiRefactor.Data.DTOs;
using AutoMapper;

namespace AcemStudios.ApiRefactor
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudioItem, GetStudioItemDto>();
            CreateMap<AddStudioItemDto, StudioItem>();
            CreateMap<StudioItem, GetStudioItemHeaderDto>();
        }
    }
}