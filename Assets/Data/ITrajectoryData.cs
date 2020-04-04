using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    [JsonObject]
    public interface ITrajectoryData
    {
        [JsonProperty]
        public List<float> X { get; set; }

        [JsonProperty]
        public List<float> Y { get; set; }

        [JsonProperty]
        public List<float> Z { get; set; }

        [JsonProperty]
        public List<float> RX { get; set; }

        [JsonProperty]
        public List<float> RY { get; set; }

        [JsonProperty]
        public List<float> RZ { get; set; }
    }
}
