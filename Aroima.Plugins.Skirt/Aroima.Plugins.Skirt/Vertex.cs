using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aroima.Plugins.Skirt
{
    public class Vertex :ICloneable
    {
        int id;
        float x;
        float y;
        float z;
        string bone1;
        string bone2;
        string bone3;
        string bone4;
        float weight1;
        float weight2;
        float weight3;
        float weight4;

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
        public int Id { get => id; set => id = value; }
        public string Bone1 { get => bone1; set => bone1 = value; }
        public float Weight1 { get => weight1; set => weight1 = value; }
        public string Bone2 { get => bone2; set => bone2 = value; }
        public float Weight2 { get => weight2; set => weight2 = value; }
        public string Bone3 { get => bone3; set => bone3 = value; }
        public float Weight3 { get => weight3; set => weight3 = value; }
        public string Bone4 { get => bone4; set => bone4 = value; }
        public float Weight4 { get => weight4; set => weight4 = value; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
