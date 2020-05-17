using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class APIImage
    {
        [JsonProperty(PropertyName ="img_src")]
        public String URL { get; set; }
        [JsonProperty(PropertyName ="earth_date")]
        public String EarthDate { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int PhotoID { get; set; }
        [JsonProperty(PropertyName = "sol")]
        public int Sol { get; set; }
        [JsonProperty(PropertyName ="rover")]
        public Rover RoverData { get; set; }

    }
}
