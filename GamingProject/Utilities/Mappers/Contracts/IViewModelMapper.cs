using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingProject.Utilities.Mappers.Contracts
{
    public interface IViewModelMapper<TDTO, TViewModel>
    {
        TViewModel MapFrom(TDTO dtoEntity);
        ICollection<TViewModel> MapFrom(ICollection<TDTO> dtoEntities);
        TDTO MapFrom(TViewModel entityVM);
        ICollection<TDTO> MapFrom(ICollection<TViewModel> entitiesVM);
    }
}
