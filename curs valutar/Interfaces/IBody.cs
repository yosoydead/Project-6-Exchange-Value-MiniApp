using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curs_valutar.Interfaces
{
    /* 
        - the body node in the xml document contains nodes called:
            - Subject -> what this document is all about
            - OrigCurrency -> what every coin converts to
            - Cube:
                - in the xml document, every given coin is stored in one node called Cube which has a attribute field called date
                    which holds the date at which the document was published (the date is not that important because it is stored
                    in the header too)
                - so, this Cube node is a list of Rates
         
         */
    public interface IBody
    {
        string Subject { get; set; }
        string OrigCurrency { get; set; }
        List<IRate> Cube { get; set; }
    }
}
