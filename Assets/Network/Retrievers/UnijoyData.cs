using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;

namespace Assets.Network.Retrievers
{
    [JsonObject]
    public class UnijoyData : ITrialData
    {
        public int Source { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public List<float> X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public List<float> Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public List<float> Z { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public List<float> RX { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public List<float> RY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public List<float> RZ { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public int NumOfObjects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public ColorData ColorData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public ObjectType ObjectType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
