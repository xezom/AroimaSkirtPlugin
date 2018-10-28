﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        string parentBoneName;
        IPXBone parentBone;
        int layerCount = 0;
        SkirtPlugin plugin;

        public List<SkirtColumn> ColumnList { get => columnList; }
        public string ParentBoneName { get => parentBoneName; set => parentBoneName = value; }
        public IPXBone ParentBone { get => parentBone; set => parentBone = value; }
        public int LayerCount { get => layerCount; set => layerCount = value; }
        public SkirtPlugin Plugin { get => plugin; set => plugin = value; }

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

    }

    public class SkirtColumn
    {
        List<SkirtBone> boneList = new List<SkirtBone>();
        string name;
        SkirtModel model;

        public string Name { get => name; set => name = value; }
        public List<SkirtBone> BoneList { get => boneList; }
        public SkirtModel Model { get => model; set => model = value; }


        public void CreatedBody()
        {


            foreach (var bone in boneList)
            {
                var body = bone.AddBody();
                if (body != null)
                    model.Plugin.PMX.Body.Add(body);
            }
            foreach (var bone in boneList)
            {
                bone.SetBodyAngle();
            }
        }

        public void CreatedJoint()
        {
            foreach (var bone in boneList)
            {
                var joint = bone.AddJoint();
                if (joint != null)
                    model.Plugin.PMX.Joint.Add(joint);
            }
        }
    }
    public class SkirtBone
    {
        int pos;
        string name;
        IPXBone bone;
        IPXVertex vertex;
        IPXBody body;
        SkirtColumn column;
        SkirtModel model;
        Matrix rotaionMatrix;


        public string Name { get => name; set => name = value; }
        public int Pos { get => pos; set => pos = value; }
        public SkirtColumn Column { get => column; set => column = value; }
        public SkirtModel Model { get => model; set => model = value; }

        /// <summary>
        /// 回転行列
        /// </summary>
        public Matrix RotaionMatrix { get => rotaionMatrix; set => rotaionMatrix = value; }

        public IPXVertex Vertex { get => vertex; set => vertex = value; }
        public IPXBone Bone { get => bone; set => bone = value; }
        public IPXBody Body { get => body; set => body = value; }



        public void CreateBone(IPXVertex v)
        {
            bone = (IPXBone)PEStaticBuilder.Pmx.Bone();
            Vertex = v;

            bone.Name = name;
            bone.Position = v.Position;
            if (Pos == 0)
                bone.Parent = Model.ParentBone;
            else
                bone.Parent = Column.BoneList[Pos - 1].Bone;

            if (Pos < Model.LayerCount - 1)
                bone.ToBone = Column.BoneList[Pos + 1].Bone;

            bone.Visible = Pos != Model.LayerCount - 1;

            if (bone.Parent != null)
                bone.Parent.ToBone = bone;
        }

        /// <summary>
        /// 新規剛体の追加
        /// </summary>
        /// <returns>剛体</returns>
        public IPXBody AddBody()
        {
            if (Body != null)
                return Body;
            Body = (IPXBody)PEStaticBuilder.Pmx.Body();
            Body.Name = bone.Name;
            Body.Bone = bone;
            Body.Mode = BodyMode.Dynamic;
            Body.Group = 9;
            Body.BoxSize.X = 0.2f;
            Body.Position = bone.Position;


            return Body;
        }
        public void SetBodyAngle()
        {
            if (bone == null)
                return;

            if (Body == null)
                return;

            var Z = -vertex.Normal;
            Z.Normalize();

            Vector3 Y = Vector3.Zero;
            if (Pos == Model.LayerCount - 1)
                Y = column.BoneList[Pos - 1].bone.Position - bone.Position;
            else
                Y = bone.Position - bone.ToBone.Position;
            Y.Normalize();

            var X = SlimDX.Vector3.Cross(Y, Z);
            X.Normalize();
            Y = SlimDX.Vector3.Cross(Z, X);


            rotaionMatrix = new Matrix();
            rotaionMatrix.M11 = X.X;
            rotaionMatrix.M12 = X.Y;
            rotaionMatrix.M13 = X.Z;
            rotaionMatrix.M21 = Y.X;
            rotaionMatrix.M22 = Y.Y;
            rotaionMatrix.M23 = Y.Z;
            rotaionMatrix.M31 = Z.X;
            rotaionMatrix.M32 = Z.Y;
            rotaionMatrix.M33 = Z.Z;

            //var rot = Geom.ToEuler_ZYX(X, Y, Z);
            //return Vec3f(x, y, z);
            var rot = Geom.ToEuler_YXZ(X, Y, Z);
            rot = -rot;

            Body.Rotation = rot;



        }

        public IPXJoint AddJoint()
        {
            if (bone == null)
                return null;
            if (bone.ToBone == null)
                return null;
            if (Body == null)
                return null;
            if (Pos == model.LayerCount - 1)
                return null;

            var nextBone = column.BoneList[Pos + 1];
            if (nextBone.body == null)
                return null;

            var joint = (IPXJoint)PEStaticBuilder.Pmx.Joint();
            joint.Name = bone.Name;
            joint.BodyA = body;
            joint.BodyB = nextBone.Body;
            joint.Position = 0.5f * (body.Position + nextBone.body.Position);
            joint.Rotation = 0.5f * (body.Rotation + nextBone.body.Rotation);

            return joint;

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

