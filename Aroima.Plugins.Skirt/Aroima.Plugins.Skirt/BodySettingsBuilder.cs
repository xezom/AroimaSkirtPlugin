using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEPlugin.Pmd;
using PEPlugin.SDX;

namespace Aroima.Plugins.Skirt
{
    /// <summary>
    /// 剛体設定生成
    /// </summary>
    public class BodySettingsBuilder
    {
        private float toRate(int layer, int layerNum)
        {
            int n = layerNum - layer;
            float x = 0.1f;
            float s = (1 - (float)Math.Pow(x, n + 1)) / (1 - x) - 1;
            s *= 9;
            return s;
        }
       


        /// <summary>
        /// 剛体設定生成
        /// </summary>
        /// <param name="layer">階層</param>
        /// <param name="layerNum">階層数</param>
        /// <returns>剛体設定</returns>
        public BodySettings Build(int layer, int layerNum)
        {
            var bs = new BodySettings()
            {
                Name = "剛体_階層" + layer.ToString(),
                Mode = layer == 0 ? BodyMode.Static : BodyMode.Dynamic,
                BoxSize = new V3(0.1f + 0.05f * layer, 0, 0),
                Mass = 2f + (-0.25f) * layer,
                Friction = 0.5f + 0.5f * layer,
                Restriction = 0,
                RotationDamping = toRate(layer, layerNum),
                PositionDamping = toRate(layer, layerNum)
            };
            return bs;
        }
    }
}
