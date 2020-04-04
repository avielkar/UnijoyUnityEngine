using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public interface IDataHandler<T> where T : IData
    {
        void Handle(string data);
    }
}
