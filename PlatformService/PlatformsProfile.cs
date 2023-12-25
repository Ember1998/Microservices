using AutoMapper;

namespace PlatformService;

public class PlatformsProfile:Profile
{
    public PlatformsProfile(){
        CreateMap<Platform,PlatformReadDTO>();
        CreateMap<PlatformCreateDTO, Platform>();
    }
}
