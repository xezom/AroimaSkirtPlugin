using PEPlugin.SDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{
    public static class V3Extentions
    {
        public static void Assign(this V3 dst, V3 src)
        {
            dst.X = src.X;
            dst.Y = src.Y;
            dst.Z = src.Z;
        }

        public static V3 ToRad(this V3 src)
        {
            return src / 180f * (float)Math.PI;
        }
    }
}
