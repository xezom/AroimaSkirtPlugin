using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimDX;
using Aroima.Plugins.Skirt;
using PEPlugin.SDX;

namespace Aroima.Plugins.SkirtTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pos = new Vector3(-1.07934f, 12.44121f, -0.9962342f);
            var normal = new Vector3(-0.4765971f, 0.3736753f, -0.7957524f);
            var to = new Vector3(-1.138259f, 12.0929f, -1.073817f);

            var y = pos - to;
            y.Normalize();

            Console.WriteLine("y=" + y.ToString());

            var z = -normal;
            z.Normalize();
            Console.WriteLine("z=" + z.ToString());
            Console.WriteLine("y*z=" + Vector3.Dot(y, z).ToString());

            var x = Vector3.Cross(z, y);
            z.Normalize();
            Console.WriteLine("x=" + x.ToString());

            y = Vector3.Cross(x, z);
            y.Normalize();
            Console.WriteLine("y=" + y.ToString());
            Console.WriteLine("y*z=" + Vector3.Dot(y, z).ToString());


            Vector3 r = Operation.EulerAngleXYZ(x, y, z);

            r *= 180f / (float)Math.PI;

            Console.WriteLine("r=" + r.ToString());

            r = Geom.ToEuler_ZYX(x, y, z);
            r *= 180f / (float)Math.PI;

            Console.WriteLine("r=" + r.ToString());


            r = Geom.ToEuler_YXZ(x, y, z);
            r *= 180f / (float)Math.PI;

            Console.WriteLine("r=" + r.ToString());

            r = Geom.ToEuler_XYZ(x, y, z);
            r *= 180f / (float)Math.PI;

            Console.WriteLine("r=" + r.ToString());
        }


    }
}
