using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.ApiCall;
using curs_valutar.Interfaces;
using curs_valutar.Models;

namespace curs_valutar.ViewModels
{
    public class BodyViewModel
    {
        //this is the entire body schema
        //its elements will be populated individually
        public Body BodyModel { get; set; }
        public List<string> currencyAbbreviations = new List<string>();
        public Dictionary<string, float> d;

        private bool? _canOperate;

        //i declared that my parser will follow the implementation of the interface
        //because, lets say, in the future, this parser will be a JSON parser instead of an XML one
        //this way, i just want a parser, doesn't matter what is uses as long as it follows the interface
        private IParser _parser;

        public BodyViewModel(){
            _parser = new Parser();
            //first, find out if i can use the xml document
            _canOperate = _parser.GetStatus();

            //populate the subject field in the body model
            LoadSubjectAndOrigCurrency();
            PopulateCurrencyAggreviations();
        }

        //based on my current view layout, i dont really need these two fields, but ill populate them
        //just in case ill modify the app in the future
        private void LoadSubjectAndOrigCurrency()
        {
            if(_canOperate == true)
            {
                var testBody = new Body();
                var subject = _parser.GetBodySubject();
                var origCurrency = _parser.GetBodyOrigCurrency();
                testBody.Subject = subject;
                testBody.OrigCurrency = origCurrency;

                BodyModel = testBody;
            }
        }

        private void PopulateCurrencyAggreviations()
        {

            if (_canOperate == true)
            {
                d = _parser.GetCubes();
                foreach (var item in d)
                {
                    currencyAbbreviations.Add(item.Key);
                }
            }
        }


    }
}
