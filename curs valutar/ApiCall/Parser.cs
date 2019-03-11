using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly string xmlUrl = @"http://www.bnr.ro/nbrfxrates.xml";

        //this grabs the entire xml document
        //private static XDocument doc = XDocument.Load(xmlUrl);

        private readonly XDocument doc = null;
        private IEnumerable<XElement> root;

        //this method tests if the connection to the url can be successfully done or not
        //even if there is not internet access, it returns false
        private bool canConnect(string url)
        {
            var result = false;
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Timeout = 5000;
                using(var response = (HttpWebResponse)request.GetResponse())
                {
                    response.Close();
                    result =  response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public Parser()
        {
            if(getStatus() == true)
            {
                doc = XDocument.Load(xmlUrl);
                root = doc.Root.Elements();
            }
            //doc = XDocument.Load(xmlUrl);
            //doc = XDocument.Load(xmlUrl);
            //doc = null;
        }

        //if i dont access the root element of the document, i cant iterate over the document
        //it just returns me the whole document and it cant be worked with
        //i also use the IEnumerable interface to make the root element a collection of elements from the xml document
        //in total i would have only two elements
        //private IEnumerable<XElement> root = doc.Root.Elements();

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

        public string getBodySubject()
        {
            //the root.Last() is the entire body tag in the xml document
            //with .Elements() i get a list of all 3 tags inside of it
            //and from that list, i need only the first item
            var subject = root.Last().Elements().ElementAt(0);
            return subject.Value;
        }

        public string getBodyOrigCurrency()
        {
            //the root.Last() is the entire body tag in the xml document
            //with .Elements() i get a list of all 3 tags inside of it
            //and from that list, i need only the second item
            var origCurrency = root.Last().Elements().ElementAt(1);
            return origCurrency.Value;
        }

        //based on the interface and model i defined, the body will have a Cubes dictionary that contains
        //as a key the coin abbreviation and as a value its monetary value
        public Dictionary<string, float> getCubes()
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
                if (item.FirstAttribute != item.LastAttribute)
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

        //this method will return true if the connection was successful
        public bool getStatus()
        {
            //if(doc == null)
            //{
            //    return false;
            //}

            //return true;
            return canConnect(xmlUrl) == true;
        }
        
    }
}
