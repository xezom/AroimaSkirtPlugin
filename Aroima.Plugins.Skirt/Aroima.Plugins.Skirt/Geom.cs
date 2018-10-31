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
        /*
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
        }*/

        public static Vector3 ToEuler_XYZ(Vector3 x, Vector3 y, Vector3 z)
        {
            if ( z.X < 1)
            {
                if (z.X > -1)
                {
                    return new Vector3()
                    {
                        X = (float)Math.Atan2(z.Y, z.Z),
                        Y = (float)Math.Asin(-z.X),
                        Z = (float)Math.Atan2(y.X, y.X)
                    };
                }
                else
                {
                    return new Vector3()
                    {
                        X = 0,
                        Y = (float)Math.PI / 2,
                        Z = -(float)Math.Atan2(-y.Z, y.Y)
                    };
                }
            }
            return new Vector3()
            {
                X = 0,
                Y = -(float)Math.PI / 2,
                Z = (float)Math.Atan2(-y.Z, y.Y)
            };
        }

        /// <summary>
        /// Y->X->Zの回転行列から、オイラー角を得る
        /// R = R_z * R_x * R_y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns>オイラー角</returns>
        public static Vector3 ToEuler_YXZ(Vector3 x, Vector3 y, Vector3 z)
        {
            if (z.Y < 1)
            {
                if (z.Y > -1)
                {
                    return new Vector3()
                    {
                        X = (float)Math.Asin(z.Y),
                        Y = (float)Math.Atan2(-z.X, z.Z),
                        Z = (float)Math.Atan2(-x.Y, y.Y)
                    };
                }
                else
                {
                    return new Vector3()
                    {
                        X = -(float)Math.PI / 2,
                        Y = 0,
                        Z = -(float)Math.Atan2(x.Z, x.X)
                    };
                }
            }
            return new Vector3()
            {
                X = (float)Math.PI/ 2,
                Y = 0,
                Z = (float)Math.Atan2(x.Z, x.X)
            };
        }

        public static Vector3 ToEuler_ZYX(Vector3 x, Vector3 y, Vector3 z)
        {
            if ( x.Z < 1)
            {
                if (x.Z > -1)
                {
                    return new Vector3()
                    {
                        X = (float)Math.Atan2(-y.Z, y.Y),
                        Y = (float)Math.Asin(x.Z),
                        Z = (float)Math.Atan2(-x.Y, x.X)
                    };
                }
                else
                {
                    return new Vector3()
                    {
                        X = -(float)Math.Atan2(y.X, y.Y),
                        Y = -(float)Math.PI / 2,
                        Z = 0
                    };
                }
            }
            else
            {
                return new Vector3()
                {
                    X = (float)Math.PI / 2,
                    Y = (float)Math.Atan2(y.X, y.Y),
                    Z = 0
                };
            }
        }
    }
}
