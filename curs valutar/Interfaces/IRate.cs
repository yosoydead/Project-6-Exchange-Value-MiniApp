using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curs_valutar.Interfaces
{
    /* 
        - in the xml document, information about each exchange value is hold in a field called Rate
        - the Rate node has 1 attribute called "currency" which holds the abbreviation of the given coin
        - some of the nodes (3 of them at the time) have an additional attribute field called "multiplier"
            which store a value of 100 meaning that 100 of the given coins have a certain value in RON
         */
    public interface IRate
    {   
        string Currency { get; set; }
        //this is going to be the actual value of the given coin (or 100 coins) in RON
        float MonetaryValue { get; set; }
    }
}
