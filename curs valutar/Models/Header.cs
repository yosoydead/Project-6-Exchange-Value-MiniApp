using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.Interfaces;

namespace curs_valutar.Models
{
    /* 
        - the xlm document has a tag named Header which  contains some data about who published the document and
            the date at which was published
        - this interface will define the schema for a class that will hold this kind of information and if there 
            will be some updates to the xml document, i can come here and modify it just a little bit
         */
    public class Header
    {
        public string Publisher { get; set; }
        public string PublishingDate { get; set; }
    }
}
