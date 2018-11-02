using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{
    public class SkirtModelBuilder
    {

        public SkirtModel Build(SkirtPlugin plugin, int colNum, int layerNum)
        {
            var bodySettingsBuilder = new BodySettingsBuilder();
            var model = new SkirtModel()
            {
                LayerCount = layerNum,
                Plugin = plugin
            };
            for (int j = 0; j < layerNum; j++)
            {
                model.BodySettingList.Add(bodySettingsBuilder.Build(j, layerNum));
                model.H_jointSettingList.Add(new JointSettings("横Joint_" + j.ToString()));
                if ( j < layerNum - 1)
                    model.V_jointSettingList.Add(new JointSettings("縦Joint_" + j.ToString()));
            }
            for (int i = 0; i < colNum; i++)
            {
                var col = new SkirtColumn()
                {
                    Name = "列" + i.ToString(),
                    Model = model
                };
                model.ColumnList.Add(col);
                for (int j = 0; j < layerNum; j++)
                {
                    var bone = new SkirtBone()
                    {
                        Name = $"スカート_{j}_{i}",
                        Model = model,
                        Row = j,
                        Column = col
                    };
                    /*
                    var b = plugin.PMX.Bone.Where(x => x.Name == bone.Name).FirstOrDefault();
                    if ( b != null )
                    {
                        bone.Bone = b;
                    }
                    var bd = plugin.PMX.Body.Where(x => x.Name == bone.Name).FirstOrDefault();
                    if (bd != null)
                    {
                        bone.Body = bd;
                    }*/
                    col.BoneList.Add(bone);
                }
            }

            return model;
        }
    }
}
