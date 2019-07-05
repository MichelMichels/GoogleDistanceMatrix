using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Entities
{
    public class Duration
    {
        [DeserializeAs(Name = "text")]
        public string Text { get; set; }

        [DeserializeAs(Name = "value")]
        public int Value { get; set; }
    }
}
