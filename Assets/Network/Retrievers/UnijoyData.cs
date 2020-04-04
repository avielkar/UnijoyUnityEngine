using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Retrievers
{
    [JsonObject]
    public class UnijoyData : IData
    {
        public int Source { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [JsonProperty]
        List<float> X;
    }
}
