using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PEPlugin.SDX;
using SlimDX;

namespace Aroima.Plugins.Skirt
{
    public static class Geom
    {
        public static Vector3 ToEuler_ZYX(Vector3 x, Vector3 y, Vector3 z)
        {
            Vector3 r = Vector3.Zero;
            if (x.Z < 1)
            {
                if (x.Z > -1)
                {
                    r.X = (float)Math.Atan2(-y.Z, z.Z);
                    r.Y = (float)Math.Asin(x.Z);
                    r.Z = (float)Math.Atan2(-x.Y, x.X);
                }
                else
                {
                    r.X = -(float)Math.Atan2(y.X, y.Y);
                    r.Y = -(float)Math.PI / 2;
                    r.Z = 0;
                }
            }
            else
            {
                r.X = (float)Math.Atan2(y.X, y.Y);
                r.Y = (float)Math.PI / 2;
                r.Z = 0;
            }
            //r *= 180f / (float)Math.PI;
            return r;
        }
    }
}
