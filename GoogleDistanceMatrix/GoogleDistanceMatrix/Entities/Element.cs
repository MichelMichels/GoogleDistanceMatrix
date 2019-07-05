using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Entities
{
    public class Element
    {
        [DeserializeAs(Name = "distance")]
        public Distance Distance { get; set; }

        [DeserializeAs(Name = "duration")]
        public Duration Duration { get; set; }

        [DeserializeAs(Name = "status")]
        public string status { get; set; }        
    }
}
