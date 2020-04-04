using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Newtonsoft.Json;

namespace Assets.Network.Retrievers
{
    public class DataRetriever<T> : IDataRetriever<T> where T : IData
    {
        public bool RetrieveData(string filePath, out T data)
        {
            try
            {
                data = JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
                return true;
            }
            catch (Exception e)
            {
                //todo::write the error.

                data = default(T);
                return false;
            }
        }
    }
}
