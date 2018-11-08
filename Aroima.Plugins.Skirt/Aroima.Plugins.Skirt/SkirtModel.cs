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
using System.IO;

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
        List<int> selectedVertex;


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


        public List<int> SelectedVertex { get => selectedVertex; set => selectedVertex = value; }

        public void CreatBody()
        {
            foreach (var col in columnList)
                col.CreatedBody();
        }

        public void RemoveAllBody()
        {
            foreach ( var col in columnList)
            {
                col.BoneList.ForEach(b => b.Body = null);
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

        public void Clear()
        {
            parentBone = null;
            columnList.ForEach(c => c.Clear());
        }

        public void UpdatePlugin()
        {
            parentBone = plugin.PMX.Bone.FirstOrDefault(x => x.Name == parentBoneName);
            columnList.ForEach(c => c.UpdatePlugin());
        }

        public void SaveToFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(SkirtModel));
            using (var stream = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
            {
                serializer.Serialize(stream, this);
            }
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

        public void Clear()
        {
            BoneList.ForEach(b => b.Clear());
        }

        public void UpdatePlugin()
        {
            BoneList.ForEach(b => b.UpdatePlugin());
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

    }
}

