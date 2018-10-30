using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace Aroima.Plugins.Skirt
{
    public class JointSettings
    {


        V3 limit_AngleHigh = new V3(30,5,5);
        V3 limit_AngleLow = new V3(-10, -5, -5);
        V3 limit_MoveHigh = new V3(0,0,0);
        V3 limit_MoveLow = new V3(0, 0, 0);
        V3 springConst_Move = new V3(5, 5, 5);
        V3 springConst_Rotate = new V3(5, 5, 5);

        public V3 Limit_AngleHigh { get => limit_AngleHigh; set => limit_AngleHigh = value; }
        public V3 Limit_AngleLow { get => limit_AngleLow; set => limit_AngleLow = value; }
        public V3 Limit_MoveHigh { get => limit_MoveHigh; set => limit_MoveHigh = value; }
        public V3 Limit_MoveLow { get => limit_MoveLow; set => limit_MoveLow = value; }
        public V3 SpringConst_Move { get => springConst_Move; set => springConst_Move = value; }
        public V3 SpringConst_Rotate { get => springConst_Rotate; set => springConst_Rotate = value; }
    }
}
