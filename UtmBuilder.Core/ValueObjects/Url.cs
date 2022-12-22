using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        
        public Url(string address)
        {
            Address = address;

            InvalidUrlException.ThrowIFInvalid(address);
        }


        public string Address { get; }

        
    }
}
