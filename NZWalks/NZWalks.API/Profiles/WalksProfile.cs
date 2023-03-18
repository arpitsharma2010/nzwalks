using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile() 
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
                .ReverseMap();

            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficultyDTO>()
                .ReverseMap();

            CreateMap<Models.DTO.AddWalkDifficultyRequest, Models.Domain.WalkDifficulty>()
                .ForMember(dest => dest.Code, options => options.MapFrom(x => x.Name));

            CreateMap<Models.DTO.UpdateWalkDifficultyRequest, Models.Domain.WalkDifficulty>()
                .ForMember(dest => dest.Code, options => options.MapFrom(x => x.Code));
        }
    }
}
