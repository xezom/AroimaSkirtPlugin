using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{
    public class BuilderBase
    {
        public static float Liner(int layer, float initValue, float increase)
        {
            return initValue + increase * layer;
        }

        public static float Liner(int layer, int layerNum, float min, float max)
        {
            return min + (max - min) * layer / (layerNum - 1);
        }
    }
}
