using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace Aroima.Plugins.Skirt
{
    public static class Validators
    {
        

        public static float GetFloat(TextBox textBox, string name)
        {
            float result = 0;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                result = 0;
            }
            else
            {
                try
                {
                    result = float.Parse(textBox.Text);
                }
                catch
                {
                    throw new ValidationException(name + "の入力が不正です", textBox);
                }
            }
            return result;
        }
        public static float GetFloat(TextBox textBox, string name, Func<float, bool> pred)
        {
            float v = GetFloat(textBox, name);
            if (!pred(v))
            {
                throw new ValidationException(name + "の入力値が範囲外です", textBox);
            }
            return v;
        }
        public static float GetFloatGTEZ(TextBox textBox, string name)
        {
            return GetFloat(textBox, name, v => v >= 0);
            // GreaterThanOrEqualZero
        }
    }
}
