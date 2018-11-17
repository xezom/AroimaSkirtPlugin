using PEPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using SlimDX;
using System;
using System.Linq;
using System.Xml.Serialization;
using log4net;

namespace Aroima.Plugins.Skirt
{
    /// <summary>
    /// スカートボーン
    /// </summary>
    public class SkirtNode
    {
        private static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        int row;
        string name;
        IPXBone bone;
        IPXVertex vertex;
        IPXBody body;
        IPXJoint v_joint;
        IPXJoint h_joint;
        SkirtColumn column;
        SkirtModel model;
        Matrix rotaionMatrix;

        V3 normal;
        V3 position;


        public string Name { get => name; set => name = value; }
        public int Row { get => row; set => row = value; }

        /// <summary>
        /// 列
        /// </summary>
        [XmlIgnore]
        public SkirtColumn Column { get => column; set => column = value; }

        /// <summary>
        /// モデル
        /// </summary>
        [XmlIgnore]
        public SkirtModel Model { get => model; set => model = value; }

        /// <summary>
        /// 回転行列
        /// </summary>
        public Matrix RotaionMatrix { get => rotaionMatrix; set => rotaionMatrix = value; }

        /// <summary>
        /// 頂点
        /// </summary>
        [XmlIgnore]
        public IPXVertex Vertex
        {
            get => vertex;
            set
            {
                vertex = value;
                normal = vertex.Normal;
                position = vertex.Position;
                if (bone != null)
                    bone.Position = vertex.Position;
            }
        }

        /// <summary>
        /// ボーン
        /// </summary>
        [XmlIgnore]
        public IPXBone Bone { get => bone; set => bone = value; }

        /// <summary>
        /// 剛体
        /// </summary>
        [XmlIgnore]
        public IPXBody Body { get => body; set => body = value; }

        /// <summary>
        /// 縦ジョイント
        /// </summary>
        [XmlIgnore]
        public IPXJoint V_Joint { get => v_joint; set => v_joint = value; }

        /// <summary>
        /// 横ジョイント
        /// </summary>
        [XmlIgnore]
        public IPXJoint H_joint { get => h_joint; set => h_joint = value; }

        /// <summary>
        /// 法線ベクトル
        /// </summary>
        public V3 Normal { get => normal; set => normal = value; }
        public V3 Position { get => position; set => position = value; }

        public SkirtNode()
        {
            normal = new V3();
            position = new V3();
        }

        /// <summary>
        /// ボーン生成
        /// </summary>
        /// <param name="v"></param>
        public void CreateBone(IPXVertex v)
        {
            if (v == null)
                throw new ApplicationException("v is null");
            bone = (IPXBone)PEStaticBuilder.Pmx.Bone();
            if (bone == null)
                throw new ApplicationException("bone is null");
            Vertex = v;
            normal = v.Normal;
            position = v.Position;

            bone.Name = name;
            bone.Position = v.Position;
            if (Row == 0)
                bone.Parent = Model.ParentBone;
            else
            {
                if (Column == null)
                    throw new ApplicationException("Column is null");
                if (Column.NodeList == null)
                    throw new ApplicationException("Column.BoneList is null");
                bone.Parent = Column.NodeList[Row - 1].Bone;
            }
            if (Row < Model.LayerCount - 1)
            {
                if (Column == null)
                    throw new ApplicationException("Column is null");
                if (Column.NodeList == null)
                    throw new ApplicationException("Column.BoneList is null");
                bone.ToBone = Column.NodeList[Row + 1].Bone;
            }

            bone.Visible = Row != Model.LayerCount - 1;

            if (bone.Parent != null)
                bone.Parent.ToBone = bone;
        }

        /// <summary>
        /// 剛体の設定
        /// 作成済みでなければ新規に作成する
        /// </summary>
        public void AddBody()
        {
            if (bone == null)
            {
                LOG.Warn("bone is not set. node=" + Name);
                return;
            }
            bool createNew = Body == null;

            if (createNew)
                Body = (IPXBody)PEStaticBuilder.Pmx.Body();
            Body.Name = bone.Name;
            Body.Bone = bone;
            Body.Position = bone.Position;

            // 剛体設定の適用
            var bs = model.BodySettingList[Row];
            UpdateBodySetting(bs);

            // 新規の場合、登録する
            if (createNew)
                model.Plugin.PMX.Body.Add(body);
        }

        /// <summary>
        /// 本体への参照を更新する
        /// </summary>
        public void UpdatePlugin()
        {
            bone = model.Plugin.PMX.Bone.FirstOrDefault(x => x.Name == name);
            body = model.Plugin.PMX.Body.FirstOrDefault(x => x.Name == name);
            v_joint = model.Plugin.PMX.Joint.FirstOrDefault(x => x.Name == name);
            h_joint = model.Plugin.PMX.Joint.FirstOrDefault(x => x.Name == "横" + name);
        }

        /// <summary>
        /// PMX本体への参照をクリアする（nullにする）
        /// </summary>
        public void Clear()
        {
            vertex = null;
            body = null;
            bone = null;
            h_joint = null;
            v_joint = null;
        }

        /// <summary>
        /// 剛体の回転を設定する
        /// </summary>
        public void SetBodyRotation()
        {
            if (bone == null)
                return;

            if (Body == null)
                return;

            // 法線の逆方向をZ軸に
            var Z = -normal;
            Z.Normalize();

            // 相対ボーン方向の逆方向をY軸に
            Vector3 Y = Vector3.Zero;
            if (Row == Model.LayerCount - 1)
                Y = column.NodeList[Row - 1].bone.Position - bone.Position;
            else
                Y = bone.Position - bone.ToBone.Position;
            Y.Normalize();

            // Y,Z軸からX軸を
            var X = SlimDX.Vector3.Cross(Y, Z);
            X.Normalize();
            // Z,X軸からY軸を
            Y = SlimDX.Vector3.Cross(Z, X);

            // 回転行列からオイラー角に変換
            var rot = Geom.ToEuler_YXZ(X, Y, Z);
            // なぜかマイナスをかける
            rot = -rot;

            Body.Rotation = rot;
        }

        /// <summary>
        /// 縦Jointの追加
        /// </summary>
        public void AddVJoint()
        {
            if (bone == null)
                return;
            if (bone.ToBone == null)
                return;
            if (Body == null)
                return;
            if (Row == model.LayerCount - 1)
                return;

            var nextBone = column.NodeList[Row + 1];
            if (nextBone.body == null)
                return;
            bool createNew = v_joint == null;

            if (createNew)
                v_joint = (IPXJoint)PEStaticBuilder.Pmx.Joint();
            v_joint.Name = bone.Name;
            v_joint.BodyA = body;
            v_joint.BodyB = nextBone.Body;
            v_joint.Position = 0.5f * (body.Position + nextBone.body.Position);
            v_joint.Rotation = 0.5f * (body.Rotation + nextBone.body.Rotation);

            var js = model.V_jointSettingList[Row];
            UpdateVJointSetting(js);
            if (createNew)
                model.Plugin.PMX.Joint.Add(v_joint);
        }

        /// <summary>
        /// 横Jointの追加
        /// </summary>
        public void AddHJoint()
        {
            if (bone == null)
                return;
            if (Body == null)
                return;
            var nextColumn = column.NextColumn();
            if (nextColumn == null)
                return;
            var nextBone = nextColumn.NodeList[Row];
            if (nextBone.body == null)
                return;


            bool createNew = H_joint == null;
            if (createNew)
                H_joint = (IPXJoint)PEStaticBuilder.Pmx.Joint();
            H_joint.Name = "横" + bone.Name;
            H_joint.BodyA = body;
            H_joint.BodyB = nextBone.Body;
            H_joint.Position = 0.5f * (body.Position + nextBone.body.Position);
            H_joint.Rotation = 0.5f * (body.Rotation + nextBone.body.Rotation);


            var js = model.H_jointSettingList[Row];
            UpdateHJointSetting(js);
            if (createNew)
                model.Plugin.PMX.Joint.Add(H_joint);
        }
        public void UpdateBodySetting(BodySettings bs)
        {
            if (Body == null)
                return;
            
            Body.Mode = bs.Mode;
            Body.BoxKind = bs.BoxKind;
            Body.BoxSize.X = bs.BoxSize.X;
            Body.BoxSize.Y = bs.BoxSize.Y;
            Body.BoxSize.Z = bs.BoxSize.Z;
            Body.Mass = bs.Mass;
            Body.PositionDamping = bs.PositionDamping;
            Body.RotationDamping = bs.RotationDamping;
            Body.Restitution = bs.Restriction;
            Body.Friction = bs.Friction;
            Body.Group = bs.Group;

            
            for (int n = 0; n < BodySettings.GROUP_SIZE; n++)
                Body.PassGroup[n] = bs.PassGroup[n];
        }

        public void UpdateVJointSetting(JointSettings js)
        {
            UpdateJointSetting(v_joint, js);
        }

        public void UpdateHJointSetting(JointSettings js)
        {
            UpdateJointSetting(H_joint, js);
        }

        public void UpdateJointSetting(IPXJoint j, JointSettings js)
        {
            if (j == null)
                return;

            j.Limit_AngleLow = js.Limit_AngleLow.Clone();
            j.Limit_AngleHigh = js.Limit_AngleHigh.Clone();

            j.Limit_MoveLow = js.Limit_MoveLow.Clone();
            j.Limit_MoveHigh = js.Limit_MoveHigh.Clone();

            j.SpringConst_Move = js.SpringConst_Move.Clone();
            j.SpringConst_Rotate = js.SpringConst_Rotate.Clone();
        }


    }
}
