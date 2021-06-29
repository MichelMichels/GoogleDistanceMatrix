using RestSharp.Deserializers;
using System.Collections.Generic;

namespace GoogleDistanceMatrix.Entities
{
    public class Row
    {
        [DeserializeAs(Name = "elements")]
        public IList<Element> Elements { get; set; }
    }
}
