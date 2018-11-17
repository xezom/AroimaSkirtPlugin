using PEPlugin.SDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{

    /// <summary>
    /// 縦Joint設定の生成
    /// </summary>
    public class HJointSettingsBuilder : BuilderBase
    {
        /// <summary>
        /// 縦Joint設定の生成
        /// </summary>
        /// <param name="layer">階層数</param>
        /// <param name="layerNum">階層総数</param>
        /// <returns></returns>
        public JointSettings Build(int layer, int layerNum)
        {
            return new JointSettings()
            {
                Name = "スカート横_階層" + layer.ToString(),
                Limit_AngleHigh = (new V3(30, 30, 30)).ToRad(),
                Limit_AngleLow = (new V3(-30, -30, -30)).ToRad(),
                Limit_MoveHigh = new V3(0.1f, 0.1f, 0.1f),
                Limit_MoveLow = new V3(-0.1f, -0.1f, -0.1f),
                SpringConst_Move = new V3(0, 0, 0),
                SpringConst_Rotate = new V3(0, 0, 0)
            };
        }
    }
}
