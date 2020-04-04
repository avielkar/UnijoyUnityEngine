using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    public interface IObjectsMetaData
    {
        public int NumOfObjects { get; set; }

        public ColorData ColorData { get; set; }

        public ObjectType ObjectType { get; set; }
    }
}
