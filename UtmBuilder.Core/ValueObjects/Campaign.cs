using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Campaign : ValueObject
    {   

        public Campaign
            (
            string source,
            string medium,
            string name
,
            string? id = null,
            string? term = null,
            string? content = null
            )
        {
            Source = source;
            Medium = medium;
            Name = name;
            Id = id;
            Term = term;
            Content = content;

            InvalidCampaignException.ThrowIfNull(item: source, "source é invalido ");
            InvalidCampaignException.ThrowIfNull(item: medium, "medium é invalido ");
            InvalidCampaignException.ThrowIfNull(item: name, "name é invalido ");
        }

        public string? Id { get; }
        public string Source { get; }
        public string Medium { get; }
        public string Name { get; }
        public string? Term { get; }
        public string? Content { get; }
    }
}
