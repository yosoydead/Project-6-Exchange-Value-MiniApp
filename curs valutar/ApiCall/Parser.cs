using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using curs_valutar.Models;


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

        public List<string> getHeaderData()
        {
            List<string> result = new List<string>();

            //this is the first node in the xml document
            var header = root.First();

            IEnumerable<XElement> headerData = header.Elements();

            foreach (var item in headerData)
            {
                result.Add(item.Value);
            }

            //only the first two elements are needed
            return result;
        }

        public Dictionary<string,float> getCubes()
        {
            //this is going to be the full dictionary containing every coin abbreviation and its monetary value in RON
            Dictionary<string, float> result = new Dictionary<string, float>();

            //accessing the body node in the xml document
            //its the second element
            var body = root.Last();

            //by accessing the first time the elements from the body i get only 3 nodes because the body node contains:
            //  - subject
            //  - origCurrency
            //  - cube
            //cube is a collection of other nodes. by using Elements() one more time, i get access to that collection of nodes
            IEnumerable<XElement> rates = body.Elements().Elements();

            foreach (var item in rates)
            {
                //initialize a dummy value for multiplier to 1 so if the value of the coin is divided by multiplier
                //and there isnt a multiplier attribute, its value doesn't change
                int multiplier = 1;

                //every rate node has 1 attribute called currency
                //there can be some nodes that have a second attribute called multiplier

                //if there is only 1 attribute on that node, it will return that attribute
                //so if both tags return the same thing, it means that the current node doesnt have
                //the multiplier attribute
                if(item.FirstAttribute != item.LastAttribute)
                {
                    multiplier = int.Parse(item.LastAttribute.Value);
                }

                //create the rate object
                var newRate = new Rate();
                newRate.Currency = item.FirstAttribute.Value;
                newRate.MonetaryValue = float.Parse(item.Value) / multiplier;

                //add the new rate to the end result
                result.Add(newRate.Currency, newRate.MonetaryValue);
            }

            return result;
        }
        
    }
}
