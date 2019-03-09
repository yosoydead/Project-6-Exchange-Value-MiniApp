using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curs_valutar.Interfaces;

namespace curs_valutar.Models
{
    public class Header : IHeader
    {
        public string Publisher { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime PublishingDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
