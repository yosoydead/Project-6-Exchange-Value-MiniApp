using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.ApiCall;
using curs_valutar.Models;

namespace curs_valutar.ViewModels
{
    public class HeaderViewModel
    {
        public Header Header { get; set; }

        private bool? canOperate;

        private Parser myParser = new Parser();
        
        public HeaderViewModel()
        {
            //first find out if i can get access to the xml
            canOperate = myParser.getStatus();
            loadHeader();
        }

        public void loadHeader()
        {
            if(canOperate == true)
            {
                //get the list that the parser hands me containing the data in the named fields from the xml
                var xmlData = myParser.getHeaderData();

                //from this list, i need only the first two items
                //create a new model
                var HeaderModel = new Header();
                HeaderModel.Publisher = xmlData[0];

                //because the datetime object returns me something that has a date like 3/8/2019 -> mm/dd/yyyy
                //and besides the date, it adds a random time like 12:00:00 AM, i decided to make the property
                //that holds the date from the interface and model to be a string not a DateTime
                //also tried ParseExact and TryParseExact methods and they did not work with any of the date formats i specified
                //it is ugly but it works
                var date = DateTime.Parse(xmlData[1]);
                string month = date.Month.ToString();
                string day = date.Day.ToString();
                string year = date.Year.ToString();
                string newDate = $"{day}-{month}-{year}";
                HeaderModel.PublishingDate = newDate;

                //at the end of the day, this model thing is going to be the data context for the view
                Header = HeaderModel;
            }
        }
    }
}
