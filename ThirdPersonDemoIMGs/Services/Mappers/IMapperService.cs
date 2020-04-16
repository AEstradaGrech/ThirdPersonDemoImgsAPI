using System;
using System.Threading.Tasks;

namespace ThirdPersonDemoIMGs.Services.Mappers
{
    public interface IMapperService<T, TDto> where T : class where TDto : class
    {
        Task<TDto> MapToDto(T entity);
        Task<T> MapToEntity(TDto dto);
    }
}
