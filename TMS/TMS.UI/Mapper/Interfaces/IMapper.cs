using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.UI.Mapper.Interfaces
{
    public interface IMapper<D, M> where D : class
                                   where M : class
    {
        M ToUiModel(D dto);

        List<M> ToUiModelList(List<D> dtos);
    }
}
