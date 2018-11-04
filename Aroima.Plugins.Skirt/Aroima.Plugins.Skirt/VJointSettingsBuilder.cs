using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEPlugin.SDX;

namespace Aroima.Plugins.Skirt
{
    public class VJointSettingsBuilder : BuilderBase
    {
        public JointSettings Build(int layer, int layerNum)
        {
            return new JointSettings()
            {
               Name = "スカート縦_階層" + layer.ToString(),
               Limit_AngleHigh = (new V3(Liner(layer, 60, -10), 5, 5)).ToRad(),
               Limit_AngleLow = (new V3(Liner(layer, layerNum, 0, -30),-5,-5)).ToRad(),
               SpringConst_Move = new V3(5, 1000, 5),
               SpringConst_Rotate = new V3(5,5,5)
            };
        }
    }
}
