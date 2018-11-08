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
                if (j < layerNum - 1)
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
            AssociateWith(model);

            UpdateSettings(model);

            return model;
        }

        private static void UpdateSettings(SkirtModel model)
        {
            var col = model.ColumnList[0];
            for (int i = 0; i < col.BoneList.Count; i++)
            {
                var b = col.BoneList[i];
                if (b.Body != null)
                {
                    var bs = model.BodySettingList[i];

                    bs.BoxKind = b.Body.BoxKind;
                    bs.BoxSize = b.Body.BoxSize.Clone();
                    bs.Friction = b.Body.Friction;
                    bs.Group = b.Body.Group;
                    bs.Mass = b.Body.Mass;
                    bs.Mode = b.Body.Mode;
                    bs.PositionDamping = b.Body.PositionDamping;
                    bs.Restriction = b.Body.Restitution;
                    bs.RotationDamping = b.Body.RotationDamping;
                    //bs.PassGroup = (int[])b.Body.PassGroup;
                }
                if (b.V_Joint != null)
                {
                    var js = model.H_jointSettingList[i];
                    js.Limit_AngleHigh = b.V_Joint.Limit_AngleHigh.Clone();
                    js.Limit_AngleLow = b.V_Joint.Limit_AngleLow.Clone();
                    js.Limit_MoveHigh = b.V_Joint.Limit_MoveHigh.Clone();
                    js.Limit_MoveLow = b.V_Joint.Limit_MoveLow.Clone();
                    js.SpringConst_Move = b.V_Joint.SpringConst_Move.Clone();
                    js.SpringConst_Rotate = b.V_Joint.SpringConst_Rotate.Clone();
                }
                if (b.H_joint != null)
                {
                    var js = model.H_jointSettingList[i];
                    js.Limit_AngleHigh = b.H_joint.Limit_AngleHigh.Clone();
                    js.Limit_AngleLow = b.H_joint.Limit_AngleLow.Clone();
                    js.Limit_MoveHigh = b.H_joint.Limit_MoveHigh.Clone();
                    js.Limit_MoveLow = b.H_joint.Limit_MoveLow.Clone();
                    js.SpringConst_Move = b.H_joint.SpringConst_Move.Clone();
                    js.SpringConst_Rotate = b.H_joint.SpringConst_Rotate.Clone();
                }
            }
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
            AssociateWith(model);
            return model;
        }

        private void AssociateWith(SkirtModel model)
        {
            model.ParentBone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == model.ParentBoneName);
            foreach (var col in model.ColumnList)
            {
                col.Model = model;
                foreach (var b in col.BoneList)
                {
                    b.Column = col;
                    b.Model = model;
                    b.Bone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == b.Name);
                    if ( b.Bone != null)
                    {
                        b.Position = b.Bone.Position;
                    }


                    b.Body = plugin.PMX.Body.FirstOrDefault(x => x.Name == b.Name);
                    b.V_Joint = plugin.PMX.Joint.FirstOrDefault(x => x.Name == b.Name);
                    b.H_joint = plugin.PMX.Joint.FirstOrDefault(x => x.Name == "横" + b.Name);
                }
            }
        }
    }
}
