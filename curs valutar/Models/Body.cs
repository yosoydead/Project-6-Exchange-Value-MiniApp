using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.Interfaces;

namespace curs_valutar.Models
{
    public class Body : IBody
    {
        public string Subject { get; set; }
        public string OrigCurrency { get; set; }
        //public List<IRate> Cube { get; set; }
    }
}
