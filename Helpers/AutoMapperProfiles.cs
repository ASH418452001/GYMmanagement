using AutoMapper;
using GYMmanagement.Entities;

namespace GYMmanagement.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<User, ClientDtO>().
                ForMember(dest => dest.Age, opt => opt.
                MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<ClientUpdateDtO, User>();

            CreateMap<RegisterDtO, User>();
            CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
            CreateMap<DateTime?, DateTime?>().ConvertUsing(d => d.HasValue ?
                DateTime.SpecifyKind(d.Value, DateTimeKind.Utc) : null);
        }


    }
}
