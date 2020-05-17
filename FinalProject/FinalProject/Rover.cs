using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Rover
    {
        [JsonProperty(PropertyName = "id")]
        public int RoverID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
        [JsonProperty(PropertyName ="status")]
        public String Status { get; set; }
    }
}
