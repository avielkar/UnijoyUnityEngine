using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnijoyData.Shared.Data;

namespace Assets.Network.Retrievers
{
    public interface IDataRetriever<T> where T : ITrialData
    {
        bool RetrieveData(string filePath , out T data);
    }
}
