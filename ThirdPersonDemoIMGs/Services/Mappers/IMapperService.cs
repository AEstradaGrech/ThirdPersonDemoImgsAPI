using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThirdPersonDemoIMGs.Services.Mappers
{
    public interface IMapperService<T, TDto> where T : class where TDto : class
    {
        Task<TDto> MapToDto(T entity);
        Task<T> MapToEntity(TDto dto);
        Task<IEnumerable<TDto>> MapManyToDto(IEnumerable<T> entities);
        Task<IEnumerable<T>> MapManyToEntity(IEnumerable<TDto> dtos);
    }
}
