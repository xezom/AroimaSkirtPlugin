using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace Aroima.Plugins.Skirt
{

    /// <summary>
    /// 剛体設定
    /// </summary>
    public class BodySettings : ICloneable
    {
        /// <summary>
        /// 非衝突グループ(PassGroup)の数
        /// </summary>
        public const int GROUP_SIZE = 16;

        string name;
        BodyMode mode = BodyMode.Dynamic;
        BodyBoxKind boxKind = BodyBoxKind.Sphere;
        V3 boxSize = new V3();
        float mass = 2;
        float positionDamping = 0.9999f;
        float rotationDamping = 0.9999f;
        float restriction = 0f;
        float friction = 0.5f;
        int group = 9;
        bool[] passGroup = new bool[GROUP_SIZE];

        #region プロパティ

        /// <summary>
        /// 剛体タイプ
        /// </summary>
        public BodyMode Mode { get => mode; set => mode = value; }

        /// <summary>
        /// 形状
        /// </summary>
        public BodyBoxKind BoxKind { get => boxKind; set => boxKind = value; }

        /// <summary>
        /// 形状のサイズ
        /// </summary>
        public V3 BoxSize { get => boxSize; set => boxSize = value; }

        /// <summary>
        /// 質量
        /// </summary>
        public float Mass { get => mass; set => mass = value; }

        /// <summary>
        /// 移動減衰
        /// </summary>
        public float PositionDamping { get => positionDamping; set => positionDamping = value; }

        /// <summary>
        /// 回転減衰
        /// </summary>
        public float RotationDamping { get => rotationDamping; set => rotationDamping = value; }

        /// <summary>
        /// 反発力
        /// </summary>
        public float Restriction { get => restriction; set => restriction = value; }

        /// <summary>
        /// 摩擦力
        /// </summary>
        public float Friction { get => friction; set => friction = value; }


        /// <summary>
        /// グループ
        /// </summary>
        public int Group { get => group; set => group = value; }

        /// <summary>
        /// 非衝突グループ
        /// </summary>
        public bool[] PassGroup { get => passGroup; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get => name; set => name = value; }

        #endregion

        /// <summary>
        /// 割り当て
        /// </summary>
        /// <param name="src">割り当て元</param>
        public void Assign(BodySettings src)
        {
       
            if ( src.name != null)
                this.name = src.name;
            this.mode = src.mode;
            this.boxKind = src.boxKind;
            this.boxSize.Assign(src.boxSize);
            this.mass = src.mass;
            this.restriction = src.restriction;
            this.friction = src.friction;
            this.restriction = src.restriction;
            //Array.Copy(src.passGroup, this.passGroup, GROUP_SIZE);
            for (int i = 0; i < GROUP_SIZE; i++)
                this.passGroup[i] = src.passGroup[i];
        }

        public object Clone()
        {
            BodySettings clone =  (BodySettings)this.MemberwiseClone();
            clone.boxSize = this.boxSize.Clone();

            return clone;
        }

        public override string ToString()
        {
            return name;
        }
    }



    
}
