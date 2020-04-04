using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Handlers
{
    public interface IDataHandler
    {
        void Handle(string data);
    }
}
