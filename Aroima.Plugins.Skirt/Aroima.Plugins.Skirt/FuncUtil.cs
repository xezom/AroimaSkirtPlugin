using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PEPlugin.SDX;

namespace Aroima.Plugins.Skirt
{
    public static class FuncUtil
    {
        public static float Liner(int layer, float initValue, float increase)
        {
            return initValue + increase * layer;
        }

        public static float Liner(int layer, int layerNum, float min, float max)
        {
            return min + (max - min) * layer / (layerNum - 1);
        }

        /// <summary>
        /// 角度→ラジアン
        /// </summary>
        /// <param name="angle">角度</param>
        /// <returns>ラジアン</returns>
        public static float toRad(float angle)
        {
            return angle / 180f * (float)Math.PI;
        }

        
    }

    public static class FloatExtentions
    {
        public static float toRad(this float angle)
        {
            return angle / 180f * (float)Math.PI;
        }

        public static float ToAngle(this float radian)
        {
            return radian / (float)Math.PI * 180f;
        }
    }
}
