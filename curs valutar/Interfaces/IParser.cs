using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace curs_valutar.Interfaces
{
    public interface IParser
    {
        //List<string> getHeaderData();
        //List<object> getBodyData();
        //Dictionary<string, float> getCube();
        bool GetStatus();
        string GetBodyOrigCurrency();
        string GetBodySubject();
        Dictionary<string, float> GetCubes();
        List<string> GetHeaderData();
        //IEnumerable<XElement> GetXmlElements();
    }
}
