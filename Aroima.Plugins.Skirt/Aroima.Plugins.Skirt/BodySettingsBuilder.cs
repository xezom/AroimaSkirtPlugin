using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{
    public class BodySettingsBuilder
    {
        public BodySettings Build(int layer, int layerNum)
        {
            var bs = new BodySettings()
            {
                Mass = 0.1f + layer * 0.05f
            };
            return bs;
        }
    }
}
