using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.ImportRepository
{
    public interface IRepository
    {
        List<AccessClientModel> Get();
    }
}
