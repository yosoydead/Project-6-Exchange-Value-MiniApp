using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace curs_valutar.ApiCall
{
    public class Parser
    {
        //this is the link for the api xml call
        private static string xmlUrl = @"http://www.bnr.ro/nbrfxrates.xml";

        //this grabs the entire xml document
        private static XDocument doc = XDocument.Load(xmlUrl);

        //if i dont access the root element of the document, i cant iterate over the document
        //it just returns me the whole document and it cant be worked with
        //i also use the IEnumerable interface to make the root element a collection of elements from the xml document
        //in total i would have only two elements
        private static IEnumerable<XElement> root = doc.Root.Elements();
        
    }
}
