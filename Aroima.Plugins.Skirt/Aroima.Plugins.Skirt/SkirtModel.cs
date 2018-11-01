using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using PEPlugin;
using PEPlugin.Form;
using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using PEPlugin.View;
using PEPlugin.Vmd;
using PEPlugin.Vme;
using SlimDX;

namespace Aroima.Plugins.Skirt
{
    
    public class SkirtModel
    {
        List<SkirtColumn> columnList = new List<SkirtColumn>();
        List<BodySettings> bodySettingList = new List<BodySettings>();
        List<JointSettings> v_jointSettingList = new List<JointSettings>();
        List<JointSettings> h_jointSettingList = new List<JointSettings>();
        string parentBoneName = "<未設定>";
        IPXBone parentBone;
        int layerCount = 0;
        SkirtPlugin plugin;


        /// <summary>
        /// 列一覧
        /// </summary>
        public List<SkirtColumn> ColumnList { get => columnList; }

        /// <summary>
        /// 親ボーン名
        /// </summary>
        public string ParentBoneName { get => parentBoneName; set => parentBoneName = value; }

        /// <summary>
        /// 親ボーン
        /// </summary>
        [XmlIgnore]
        public IPXBone ParentBone { get => parentBone; set => parentBone = value; }

        /// <summary>
        /// 層数
        /// </summary>
        public int LayerCount { get => layerCount; set => layerCount = value; }

        [XmlIgnore]
        public SkirtPlugin Plugin { get => plugin; set => plugin = value; }
        public List<BodySettings> BodySettingList { get => bodySettingList; set => bodySettingList = value; }
        public List<JointSettings> V_jointSettingList { get => v_jointSettingList; set => v_jointSettingList = value; }
        public List<JointSettings> H_jointSettingList { get => h_jointSettingList; set => h_jointSettingList = value; }

        public void CreatBody()
        {
            foreach (var col in columnList)
                col.CreatedBody();
        }

        public void RemoveAllBody()
        {
            foreach ( var col in columnList)
            {
                foreach ( var bone in col.BoneList)
                {
                    bone.Body = null;
                }
            }
        }

        public SkirtColumn NextColumn(SkirtColumn col)
        {
            for (int i = 0; i < columnList.Count; i++)
                if (columnList[i] == col)
                {
                    if (i == columnList.Count - 1)
                        return columnList[0];
                    else
                        return columnList[i + 1];
                    
                }
            return null;

        }

    }

    /// <summary>
    /// 列
    /// </summary>
    public class SkirtColumn
    {
        List<SkirtBone> boneList = new List<SkirtBone>();
        string name;
        SkirtModel model;

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// ボーンリスト
        /// </summary>
        [XmlArray("Bones")]
        public List<SkirtBone> BoneList { get => boneList; }

        /// <summary>
        /// モデル
        /// </summary>
        [XmlIgnore]
        public SkirtModel Model { get => model; set => model = value; }

        /// <summary>
        /// 剛体を一気に作成する
        /// </summary>
        public void CreatedBody()
        {
            boneList.ForEach(b => b.AddBody());
            boneList.ForEach(b => b.SetBodyRotation());
        }

        /// <summary>
        /// 縦Jointの作成
        /// </summary>
        public void CreateVJoint()
        {
            boneList.ForEach(b => b.AddVJoint());
        }

        /// <summary>
        /// 横Jointの作成
        /// </summary>
        public void CreateHJoint()
        {
            boneList.ForEach(b => b.AddHJoint());
        }
    }

    /// <summary>
    /// スカートボーン
    /// </summary>
    public class SkirtBone
    {
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

        public SkirtBone()
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
            bone = (IPXBone)PEStaticBuilder.Pmx.Bone();
            Vertex = v;
            normal = v.Normal;
            position = v.Position;

            bone.Name = name;
            bone.Position = v.Position;
            if (Row == 0)
                bone.Parent = Model.ParentBone;
            else
                bone.Parent = Column.BoneList[Row - 1].Bone;

            if (Row < Model.LayerCount - 1)
                bone.ToBone = Column.BoneList[Row + 1].Bone;

            bone.Visible = Row != Model.LayerCount - 1;

            if (bone.Parent != null)
                bone.Parent.ToBone = bone;
        }

        /// <summary>
        /// 新規剛体の追加
        /// </summary>
        public void AddBody()
        {
            bool createNew = Body == null;
            //MessageBox.Show("BodyNull:" + createNew.ToString());
            if (createNew)
                Body = (IPXBody)PEStaticBuilder.Pmx.Body();
            Body.Name = bone.Name;
            Body.Bone = bone;
            Body.Position = bone.Position;

            // パラメータの適用
            var bs = model.BodySettingList[Row];
            UpdateBodySetting(bs);

            if (createNew)
                model.Plugin.PMX.Body.Add(body);
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
            var Z = -vertex.Normal;
            Z.Normalize();

            // 相対ボーン方向の逆方向をY軸に
            Vector3 Y = Vector3.Zero;
            if (Row == Model.LayerCount - 1)
                Y = column.BoneList[Row - 1].bone.Position - bone.Position;
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

            var nextBone = column.BoneList[Row + 1];
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
            var nextColumn = model.NextColumn(Column);
            if (nextColumn == null)
                return;
            var nextBone = nextColumn.BoneList[Row];
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
            for (int n = 0; n < 16; n++)
                Body.PassGroup[n] = bs.PassGroup[n] == 1;
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



    public class Operation
    {
        public static SlimDX.Quaternion FromTwoVector(SlimDX.Vector3 u, SlimDX.Vector3 v)
        {
            /*
                float norm_u_norm_v = sqrt(sqlength(u) * sqlength(v));
                vec3 w = cross(u, v);
                quat q = quat(norm_u_norm_v + dot(u, v), w.x, w.y, w.z);
                return normalize(q);
            */
            var norm_u_norm_v = (float)Math.Sqrt(u.LengthSquared() * v.LengthSquared());
            var w = SlimDX.Vector3.Cross(u, v);
            var dot = SlimDX.Vector3.Dot(u, v);
            var q = new SlimDX.Quaternion(w.X, w.Y, w.Z, norm_u_norm_v + dot);
            q.Normalize();
            return q;
        }

        public static SlimDX.Vector3 ToEuler(SlimDX.Quaternion q)
        {
            float sqw = q.W * q.W;
            float sqx = q.X * q.X;
            float sqy = q.Y * q.Y;
            float sqz = q.Z * q.Z;

            var result = SlimDX.Vector3.Zero;

            //roll (X):
            float sr = 2f * (q.W * q.X + q.Y * q.Z);
            float cr = 1f - 2f * (sqx + sqy);
            result.X = (float)Math.Atan2(sr, cr);
            //pitch (Y):
            float sip = 2f * (q.W * q.Y - q.Z * q.X);
            result.Y = Math.Abs(sip) >= 1 ? CopySign((float)Math.PI / 2, sip)
                : (float)Math.Asin(sip);
            //yaw (Z):
            float sy = 2f * (q.W * q.Z + q.X * q.Y);
            float cy = 1f - 2f * (sqy + sqz);
            result.Z = (float)Math.Atan2(sy, cy);
            /*
            result.X = result.X / (float)Math.PI * 180f;
            result.Y = result.Y / (float)Math.PI * 180f;
            result.Z = result.Z / (float)Math.PI * 180f;
            */
            return result;
        }

        public static float CopySign(float x, float y)
        {
            var abs = x >= 0 ? x : -x;
            if (y >= 0)
                return abs;
            else
                return -abs;
        }
        /// <summary>
        /// 剛体の回転から回転行列を取得する。
        /// </summary>
        /// <param name="Body"></param>
        /// <returns></returns>
        public static SlimDX.Matrix GetBodyMatrix(IPXBody Body)
        {
            return GetPhyObjectMatrix(Body.Rotation);
        }
        /// <summary>
        /// Jointの回転から回転行列を取得する。
        /// </summary>
        /// <param name="Joint"></param>
        /// <returns></returns>
        public static SlimDX.Matrix GetJointMatrix(IPXJoint Joint)
        {
            return GetPhyObjectMatrix(Joint.Rotation);
        }
        /// <summary>
        /// 剛体・Jointの回転から回転行列を取得する。
        /// </summary>
        /// <param name="Joint"></param>
        /// <returns></returns>
        public static SlimDX.Matrix GetPhyObjectMatrix(V3 Rotation)
        {
            return SlimDX.Matrix.RotationYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z);
        }

        /// <summary>
        /// 2頂点からなるベクトルからローカル軸を取得する。
        /// 外積を使用してみる
        /// </summary>
        /// <param name="Bone"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public static void GetLocalAxis2(IPXBone Bone, out V3 X, out V3 Y, out V3 Z)
        {
            V3 StartPosition = Bone.Position;
            V3 EndPosition = SlimDX.Vector3.Zero;
            if (!Bone.IsToBone())
            {
                EndPosition = StartPosition + Bone.ToOffset;
            }
            else
            {
                EndPosition = Bone.ToBone.Position;
            }
            GetLocalAxis2(StartPosition, EndPosition, out X, out Y, out Z);
        }

        /// <summary>
        /// 2頂点からなるベクトルからローカル軸を取得する。
        /// 外積を使用してみる
        /// </summary>
        /// <param name="StartPosition">開始点</param>
        /// <param name="EndPosition">終了点</param>
        /// <param name="X">ローカルX軸</param>
        /// <param name="Y">ローカルY軸</param>
        /// <param name="Z">ローカルZ軸</param>
        public static void GetLocalAxis2(V3 StartPosition, V3 EndPosition, out V3 X, out V3 Y, out V3 Z)
        {
            V3 LocalX = EndPosition - StartPosition;
            //向きがある場合のみ処理。
            if (LocalX != SlimDX.Vector3.Zero)
            {
                LocalX.Normalize();
                //Yが負の時に反転する。
                if (LocalX.Y <= -float.Epsilon)
                {
                    LocalX = -LocalX;
                }
                //X軸とする。
                X = LocalX;
                //XとGlobalZ軸の単位ベクトルとの外積を取りXに垂直なベクトルを取得してそれをYとする。
                Y = SlimDX.Vector3.Cross(X, SlimDX.Vector3.UnitZ);
                Y.Normalize();
                //XとYの外積を取りYに垂直なベクトルを取得してそれをZとする。
                Z = SlimDX.Vector3.Cross(Y, X);
                Z.Normalize();
            }
            else
            {
                throw new System.Exception("軸が存在しません。");
            }
        }
        /// <summary>
        /// ボーンのToBone/ToOffsetの値からLocal軸の値を取得する。
        /// くぉーたにおんを使ってみる
        /// 要SlimDX
        /// </summary>
        /// <param name="Bone">ボーン</param>
        /// <param name="x">Local軸（X）</param>
        /// <param name="y">Local軸（Y）</param>
        /// <param name="z">Local軸（Z）</param>
        public static void GetLocalAxis(IPXBone Bone, out V3 x, out V3 y, out V3 z)
        {
            V3 StartPosition = Bone.Position;
            V3 EndPosition = SlimDX.Vector3.Zero;
            //ボーンの向きの取得
            if (Bone.IsToBone())
            {
                EndPosition = Bone.ToBone.Position;
            }
            else
            {
                EndPosition = Bone.Position + Bone.ToOffset;
            }
            GetLocalAxis(StartPosition, EndPosition, out x, out y, out z);
        }
        /// <summary>
        /// ２つの位置からLocal軸の値を取得する。
        /// くぉーたにおんを使ってみる
        /// 要SlimDX
        /// </summary>
        /// <param name="StartPosition">開始位置</param>
        /// <param name="EndPosition">終了位置</param>
        /// <param name="x">Local軸（X）</param>
        /// <param name="y">Local軸（Y）</param>
        /// <param name="z">Local軸（Z）</param>
        public static void GetLocalAxis(V3 StartPosition, V3 EndPosition, out V3 x, out V3 y, out V3 z)
        {
            V3 V = EndPosition - StartPosition;
            //向きがある場合のみ処理。
            if (V != SlimDX.Vector3.Zero)
            {
                V3 X = SlimDX.Vector3.UnitX;
                V3 Y = SlimDX.Vector3.UnitY;
                V3 Z = SlimDX.Vector3.UnitZ;
                V.Normalize();
                //向きがZ方向の場合
                if (V == SlimDX.Vector3.UnitZ)
                {
                    X = SlimDX.Vector3.UnitZ;
                    Z = -SlimDX.Vector3.UnitX;

                }
                //向きが-Z方向の場合
                else if (V == -SlimDX.Vector3.UnitZ)
                {
                    X = -SlimDX.Vector3.UnitZ;
                    Z = SlimDX.Vector3.UnitX;
                }
                //それ以外の場合
                else
                {
                    V.Normalize();
                    //向きが単位ベクトルXになるクォータニオンを取得
                    Q Qu = Q.Dir(V, SlimDX.Vector3.UnitZ, SlimDX.Vector3.UnitX, SlimDX.Vector3.UnitZ);
                    //クォータニオンから回転行列を取得
                    SlimDX.Matrix Ma = Qu.ToMatrix();

                    //回転行列の要素から各軸の向きを取得（PMXEの結果と微妙にずれるときがある。）
                    X = new V3(Ma.M11, Ma.M12, Ma.M13);
                    Y = new V3(Ma.M21, Ma.M22, Ma.M23);
                    Z = new V3(Ma.M31, Ma.M32, Ma.M33);
                }
                //取得した向きをノーマライズ
                X.Normalize();
                Y.Normalize();
                Z.Normalize();
                x = X;
                y = Y;
                z = Z;
            }
            else
            {
                throw new System.Exception("ローカル軸を取得できません。");
            }
        }
        /// <summary>
        /// Jointの回転からローカル軸を取得する。
        /// </summary>
        /// <param name="Joint"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public static void GetLocalAxis(IPXJoint Joint, out V3 X, out V3 Y, out V3 Z)
        {
            GetLocalAxis(Joint.Rotation, out X, out Y, out Z);
        }
        /// <summary>
        /// 剛体の回転からローカル軸を取得する。
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public static void GetLocalAxis(IPXBody Body, out V3 X, out V3 Y, out V3 Z)
        {
            GetLocalAxis(Body.Rotation, out X, out Y, out Z);
        }
        /// <summary>
        /// 剛体/Jointの回転からローカル軸を取得する。
        /// </summary>
        /// <param name="Rotation"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public static void GetLocalAxis(V3 Rotation, out V3 X, out V3 Y, out V3 Z)
        {
            X = SlimDX.Vector3.UnitX;
            Y = SlimDX.Vector3.UnitY;
            Z = SlimDX.Vector3.UnitZ;
            SlimDX.Matrix Matrix = GetPhyObjectMatrix(Rotation);
            X = new PEPlugin.SDX.V4(SlimDX.Vector3.Transform(X, Matrix)).ToV3();
            Y = new PEPlugin.SDX.V4(SlimDX.Vector3.Transform(Y, Matrix)).ToV3();
            Z = new PEPlugin.SDX.V4(SlimDX.Vector3.Transform(Z, Matrix)).ToV3();
            X.Normalize();
            Y.Normalize();
            Z.Normalize();
        }


        /// <summary>
        /// オイラー角を取り出す。（XYZ）
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static V3 EulerAngleXYZ(V3 X, V3 Y, V3 Z)
        {
            V3 ret = SlimDX.Vector3.Zero;
            ret.Z = (float)Math.Atan2(X.Y, X.X);
            ret.Y = (float)Math.Asin(-X.Z);
            if (Math.Abs(Math.Cos(ret.Y)) > double.Epsilon)
            {
                ret.X = (float)Math.Asin(Y.Z / (float)Math.Cos(ret.Y));
                if (Z.Z <= float.Epsilon)
                {
                    ret.X = (float)Math.PI - ret.X;
                }
            }
            else
            {
                ret.Z = (float)Math.Atan2(-Y.X, Y.Y);
            }
            return ret;
        }
        /// <summary>
        /// オイラー角を取り出す。（ZXY）
        /// </summary>
        /// <param name="X">X軸ベクトル</param>
        /// <param name="Y">Y軸ベクトル</param>
        /// <param name="Z">Z軸ベクトル</param>
        /// <returns>オイラー角ベクトル</returns>
        public static V3 EulerAngleZXY(V3 X, V3 Y, V3 Z)
        {
            V3 ret = SlimDX.Vector3.Zero;
            ret.Y = (float)Math.Atan2(Z.X, Z.Z);
            ret.X = (float)Math.Asin(Z.Y);
            if (Math.Abs(Math.Cos(ret.X)) > double.Epsilon)
            {
                ret.Z = (float)Math.Asin(X.Y / (float)Math.Cos(ret.X));
                if (Y.Y <= float.Epsilon)
                {
                    ret.Z = (float)Math.PI - ret.Z;
                }
            }
            else
            {
                ret.Y = (float)Math.Atan2(-X.Z, X.X);
            }
            return ret;
        }
    }


    public static class Vector4Extentions
    {
        /// <summary>
        /// Vector4形式をV3形式に変換
        /// 要SlimDX
        /// </summary>
        /// <param name="V">Vector4形式の値</param>
        /// <returns>V3形式の値</returns>
        public static V3 ToV3(this SlimDX.Vector4 V)
        {
            return new V3(V.X, V.Y, V.Z);
        }
    }

    public static class Vector3Extentions
    {
        /// <summary>
        /// Vector3形式をV3形式に変換
        /// 要SlimDX
        /// </summary>
        /// <param name="V">Vector3形式の値</param>
        /// <returns>V3形式の値</returns>
        public static V3 Vector3ToV3(this SlimDX.Vector3 V)
        {
            return new V3(V.X, V.Y, V.Z);
        }
    }


    public static class IPXBoneExtentions
    {
        /// <summary>
        /// ボーンのToBoneが有効かどうか
        /// </summary>
        /// <param name="Bone">ボーン</param>
        /// <returns>ToBoneが有効かどうか</returns>
        public static bool IsToBone(this IPXBone Bone)
        {
            if (Bone.ToBone == null)
            {
                return false;
            }
            else
            {
                if (Bone.ToOffset == SlimDX.Vector3.Zero)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// ボーンのローカル軸から剛体の回転を取得する。
        /// </summary>
        /// <param name="Bone"></param>
        /// <returns>剛体の回転</returns>
        public static V3 ToBodyAngle(this IPXBone Bone)
        {
            V3 X, Y, Z;
            Operation.GetLocalAxis2(Bone, out X, out Y, out Z);
            return Operation.EulerAngleXYZ(X, Y, Z);
        }
    }
}

