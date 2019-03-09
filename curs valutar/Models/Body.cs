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
        public string Subject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OrigCurrency { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IRate> Cube { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
