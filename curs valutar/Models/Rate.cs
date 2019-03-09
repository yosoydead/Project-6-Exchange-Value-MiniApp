using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.Interfaces;

namespace curs_valutar.Models
{
    public class Rate : IRate
    {
        public string Currency { get; set; }
        public float MonetaryValue { get; set; }
    }
}
