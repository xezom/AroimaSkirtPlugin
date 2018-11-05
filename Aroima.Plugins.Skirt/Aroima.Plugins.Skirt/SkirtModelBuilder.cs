using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Aroima.Plugins.Skirt
{
    public class SkirtModelBuilder
    {
        SkirtPlugin plugin;

        public SkirtModelBuilder(SkirtPlugin plugin)
        {
            this.plugin = plugin;
        }

        public SkirtModel Build(int colNum, int layerNum)
        {
            var bodySettingsBuilder = new BodySettingsBuilder();
            var vJointSettingsBuilder = new VJointSettingsBuilder();
            var hJointSettingsBuilder = new HJointSettingsBuilder();
            var model = new SkirtModel()
            {
                LayerCount = layerNum,
                Plugin = plugin
            };
            for (int j = 0; j < layerNum; j++)
            {
                model.BodySettingList.Add(bodySettingsBuilder.Build(j, layerNum));
                model.H_jointSettingList.Add(hJointSettingsBuilder.Build(j, layerNum));
                if ( j < layerNum - 1)
                    model.V_jointSettingList.Add(vJointSettingsBuilder.Build(j, layerNum));
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
                    

                    col.BoneList.Add(bone);
                }
            }

            return model;
        }

        public SkirtModel LoadFromFile(string fileName)
        {
            SkirtModel model;
            var serializer = new XmlSerializer(typeof(SkirtModel));
            using (var stream = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                model = (SkirtModel)serializer.Deserialize(stream);
            }
            // 関連付ける
            model.Plugin = plugin;
            model.ParentBone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == model.ParentBoneName);
            foreach (var col in model.ColumnList)
            {
                col.Model = model;
                foreach (var b in col.BoneList)
                {
                    b.Column = col;
                    b.Model = model;
                    b.Bone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == b.Name);
                    b.Body = plugin.PMX.Body.FirstOrDefault(x => x.Name == b.Name);
                    b.V_Joint = plugin.PMX.Joint.FirstOrDefault(x => x.Name == b.Name);
                    b.H_joint = plugin.PMX.Joint.FirstOrDefault(x => x.Name == "横" + b.Name);
                }
            }
            return model;
        }
    }
}
