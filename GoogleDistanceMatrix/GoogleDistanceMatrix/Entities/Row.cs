using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Entities
{
    public class Row
    {
        [DeserializeAs(Name = "elements")]
        public IList<Element> Elements { get; set; }
    }
}
