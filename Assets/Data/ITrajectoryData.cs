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
        List<float> X { get; set; }

        [JsonProperty]
        List<float> Y { get; set; }

        [JsonProperty]
        List<float> Z { get; set; }

        [JsonProperty]
        List<float> RX { get; set; }

        [JsonProperty]
        List<float> RY { get; set; }

        [JsonProperty]
        List<float> RZ { get; set; }
    }
}
