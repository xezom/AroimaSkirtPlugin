using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{
    /// <summary>
    /// 設定生成クラスの基底クラス
    /// </summary>
    public class BuilderBase
    {
        /// <summary>
        /// 線形補間
        /// </summary>
        /// <param name="n"></param>
        /// <param name="initValue">初期値</param>
        /// <param name="increment">増分</param>
        /// <returns></returns>
        public static float Liner(int n, float initValue, float increment)
        {
            return initValue + increment * n;
        }

        /// <summary>
        /// 線形補間
        /// </summary>
        /// <param name="n"></param>
        /// <param name="nMax"></param>
        /// <param name="min">最小値</param>
        /// <param name="max">最大値</param>
        /// <returns></returns>
        public static float Liner(int n, int nMax, float min, float max)
        {
            return min + (max - min) * n / (nMax - 1);
        }
    }
}
