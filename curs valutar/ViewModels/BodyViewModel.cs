using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.ApiCall;
using curs_valutar.Models;

namespace curs_valutar.ViewModels
{
    public class BodyViewModel
    {
        //this is the entire body schema
        //its elements will be populated individually
        public Body BodyModel { get; set; }
        public List<string> currencyAbbreviations = new List<string>();

        private bool? _canOperate;

        private Parser _parser = new Parser();
        public Dictionary<string, float> d;

        public BodyViewModel(){

            //first, find out if i can use the xml document
            _canOperate = _parser.getStatus();

            //populate the subject field in the body model
            loadSubjectAndOrigCurrency();
            populateCurrencyAggreviations();
        }

        //based on my current view layout, i dont really need these two fields, but ill populate them
        //just in case ill modify the app in the future
        private void loadSubjectAndOrigCurrency()
        {
            if(_canOperate == true)
            {
                var testBody = new Body();
                var subject = _parser.getBodySubject();
                var origCurrency = _parser.getBodyOrigCurrency();
                testBody.Subject = subject;
                testBody.OrigCurrency = origCurrency;

                BodyModel = testBody;
            }
        }

        private void populateCurrencyAggreviations()
        {

            if (_canOperate == true)
            {
                d = _parser.getCubes();
                foreach (var item in d)
                {
                    currencyAbbreviations.Add(item.Key);
                }
            }
        }


    }
}
