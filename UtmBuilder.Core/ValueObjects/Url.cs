using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        
        public Url(string address)
        {
            Address = address;

            InvalidUrlException.ThrowIFInvalidUrl(address);
        }


        public string Address { get; }

        
    }
}
