using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curs_valutar.Interfaces
{
    public interface IParser
    {
        List<string> getHeaderData();
        List<object> getBodyData();
        Dictionary<string, float> getCube();
    }
}
