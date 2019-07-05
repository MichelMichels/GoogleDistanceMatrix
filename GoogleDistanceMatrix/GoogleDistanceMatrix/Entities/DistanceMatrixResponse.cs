using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleDistanceMatrix.Entities
{
    public class DistanceMatrixResponse
    {
        [DeserializeAs(Name = "destination_addresses")]
        public IList<string> DestinationAddresses { get; set; }

        [DeserializeAs(Name = "origin_addresses")]
        public IList<string> OriginAddresses { get; set; }

        [DeserializeAs(Name = "rows")]
        public IList<Row> Rows { get; set; }

        [DeserializeAs(Name = "status")]
        public string Status { get; set; }
    }
}
