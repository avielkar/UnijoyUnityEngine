﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Network.Retrievers
{
    public interface IDataRetriever
    {
        void RetrieveData(string filePath);
    }
}
