using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Retrievers
{
    public class UnijoyDataRetriever : IDataRetriever<UnijoyData>
    {
        public bool RetrieveData(string filePath, out UnijoyData data)
        {
            try
            {
                data = JsonConvert.DeserializeObject<UnijoyData>(File.ReadAllText(filePath));
                return true;
            }
            catch (Exception e)
            {
                //todo::write the error.

                data = null;
                return false;
            }
        }
    }
}
