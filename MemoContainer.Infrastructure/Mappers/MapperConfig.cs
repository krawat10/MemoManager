using AutoMapper;
using MemoContainer.Core.Domain;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Mappers
{
    public static class MapperConfig
    {
        public static IMapper Initalize()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Memo, MemoDTO>();
                cfg.CreateMap<User, UserDTO>();
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}