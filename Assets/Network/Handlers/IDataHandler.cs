﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets.Data;
using Assets.Network.Retrievers;

namespace Assets.Network.Handlers
{
    public interface IDataHandler
    {
        void Handle(string data);
    }
}
