using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public class InvalidUrlException : Exception
    {

        private const string DefaultErrorMessage = "Url inválida";
        private const string UrlRegexPattern =
            @"^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$";


        public InvalidUrlException(string message = DefaultErrorMessage)
            : base(message) 
        {

        }

        public static void ThrowIFInvalid(
            string address,
            string message = DefaultErrorMessage)
        {
            if(string.IsNullOrEmpty(address))
                throw new InvalidUrlException();

            if (!Regex.IsMatch(address, UrlRegexPattern))
                throw new InvalidUrlException();
        }
    }
}
