using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCode.Repository
{
    public interface IMapper<Def, My>
        where Def : class
        where My : class
    {
        My MappingToDefU(Def entity);
        Def MappingFromDefU(My entity);
    }
}
