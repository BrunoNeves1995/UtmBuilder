using System.Linq;
using System.Text;
using UtmBuilder.Core;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core
{
    public class Utm
    {
        public Utm(
            Url url, 
            Campaign campaign)
        {
            Url = url;
            Campaign = campaign;
        }
        public Url Url { get;} 
        public Campaign Campaign { get;}

        // deixando automatico a conversão de um UTM para o tipo string
        public static implicit operator string(Utm utm)
            => utm.ToString();

        public static implicit operator Utm(string link)
        {
            if (string.IsNullOrEmpty(link))
                throw new InvalidUrlException();

            var url = new Url(link);
            var segments = url.Address.Split(separator: "?");

            if(segments.Length == 1)
                throw new InvalidUrlException(message: "Nenhum segmento foi fornecido");

            var param = segments[1].Split(separator: "&");
            var utm_source = param.Where(x => x.StartsWith("utm_source")).FirstOrDefault("").Split(separator: "=")[1];
            var utm_medium = param.Where(x => x.StartsWith("utm_medium")).FirstOrDefault("").Split(separator: "=")[1];
            var utm_campaign = param.Where(x => x.StartsWith("utm_campaign")).FirstOrDefault("").Split(separator: "=")[1];
            var utm_id = param.Where(x => x.StartsWith("utm_id")).FirstOrDefault("").Split(separator: "=")[1];
            var utm_term = param.Where(x => x.StartsWith("utm_term")).FirstOrDefault("").Split(separator: "=")[1];
            var utm_content = param.Where(x => x.StartsWith("utm_content")).FirstOrDefault("").Split(separator: "=")[1];

            var utm = new Utm(
                new Url(segments[0]),
                new Campaign(utm_source, utm_medium, utm_campaign, utm_id, utm_term, utm_content));

            return utm;
        }

        public override string ToString()
        {
            var segmets = new List<string>();
            segmets.AddIfNotNull("utm_source", Campaign.Source);
            segmets.AddIfNotNull("utm_medium", Campaign.Medium);
            segmets.AddIfNotNull("utm_campaign", Campaign.Name) ;
            segmets.AddIfNotNull("utm_id", Campaign.Id);
            segmets.AddIfNotNull("utm_term", Campaign.Term);
            segmets.AddIfNotNull("utm_content", Campaign.Content);


            return $"{Url.Address}?{string.Join("&", segmets)}";
        }

    }
}
