using System;
using System.Collections.Generic;
using System.Text;

namespace GamingProject.Services.Mappers.Contract
{
    public interface IDTOServiceMapper<TEntity, TDto>
    {
        TDto MapFrom(TEntity entity);
        ICollection<TDto> MapFrom(ICollection<TEntity> entities);
    }
}
