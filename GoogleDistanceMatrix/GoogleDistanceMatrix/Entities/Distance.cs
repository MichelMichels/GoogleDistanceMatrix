using RestSharp.Deserializers;

namespace GoogleDistanceMatrix.Entities
{
    public class Distance
    {
        [DeserializeAs(Name = "text")]
        public string Text { get; set; }

        [DeserializeAs(Name = "value")]
        public int Value { get; set; }
    }
}
