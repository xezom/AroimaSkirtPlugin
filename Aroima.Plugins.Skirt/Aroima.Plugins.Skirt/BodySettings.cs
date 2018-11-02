﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PEPlugin.Pmd;
using PEPlugin.Pmx;
using PEPlugin.SDX;

namespace Aroima.Plugins.Skirt
{
    public class BodySettings
    {
        BodyMode mode = BodyMode.Dynamic;
        BodyBoxKind boxKind = BodyBoxKind.Sphere;
        V3 boxSize = new V3();
        float mass = 2;
        float positionDamping = 0.9999f;
        float rotationDamping = 0.9999f;
        float restriction = 0f;
        float friction = 0.5f;
        int group = 9;
        int[] passGroup = new int[16];


        public BodyMode Mode { get => mode; set => mode = value; }
        public BodyBoxKind BoxKind { get => boxKind; set => boxKind = value; }
        public V3 BoxSize { get => boxSize; set => boxSize = value; }
        public float Mass { get => mass; set => mass = value; }
        public float PositionDamping { get => positionDamping; set => positionDamping = value; }
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
        public int[] PassGroup { get => passGroup; }

        public void Assign(BodySettings src)
        {
            this.mode = src.mode;
            this.boxKind = src.boxKind;
            this.boxSize.Assign(src.boxSize);
            this.mass = src.mass;
            this.restriction = src.restriction;
            this.friction = src.friction;

        }
    }



    
}
