using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Aroima.Plugins.Skirt
{
    /// <summary>
    /// スカートモデルの列
    /// </summary>
    public class SkirtColumn
    {
        List<SkirtNode> nodeList = new List<SkirtNode>();
        string name;
        SkirtModel model;
        int pos;

        #region プロパティ

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// ボーンリスト
        /// </summary>
        [XmlArray("Bones")]
        public List<SkirtNode> NodeList { get => nodeList; }

        /// <summary>
        /// モデル
        /// </summary>
        [XmlIgnore]
        public SkirtModel Model { get => model; set => model = value; }

        /// <summary>
        /// 位置
        /// </summary>
        public int Pos { get => pos; set => pos = value; }

        #endregion

        /// <summary>
        /// 次の列を返す
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public SkirtColumn NextColumn()
        {

            if (Pos == model.ColumnList.Count - 1)
                return model.ColumnList[0];
            else if (Pos < model.ColumnList.Count - 1)
                return model.ColumnList[Pos + 1];
            else
                return null;
        }


        /// <summary>
        /// 剛体を一気に作成する
        /// </summary>
        public void CreatedBody()
        {
            // 剛体を生成
            nodeList.ForEach(b => b.AddBody());
            // 剛体の回転を設定
            nodeList.ForEach(b => b.SetBodyRotation());
        }

        /// <summary>
        /// 縦Jointの作成
        /// </summary>
        public void CreateVJoint()
        {
            nodeList.ForEach(b => b.AddVJoint());
        }

        /// <summary>
        /// 横Jointの作成
        /// </summary>
        public void CreateHJoint()
        {
            nodeList.ForEach(b => b.AddHJoint());
        }

        /// <summary>
        /// MX本体への参照をクリアする（nullにする）
        /// </summary>
        public void Clear()
        {
            NodeList.ForEach(b => b.Clear());
        }

        /// <summary>
        /// 本体への参照を更新する
        /// </summary>
        public void UpdatePlugin()
        {
            NodeList.ForEach(b => b.UpdatePlugin());
        }
    }
}
