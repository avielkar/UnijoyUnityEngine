using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.Random
{
    public static class RandomExtensions
    {
        public static float NextFloat(this System.Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);
            return BitConverter.ToSingle(buffer, 0);
        }
    }
}
