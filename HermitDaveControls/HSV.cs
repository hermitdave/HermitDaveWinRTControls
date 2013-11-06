using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HermitDaveControls
{
    public struct HSV
    {
        public float Hue;
        public float Saturation;
        public float Value;

        public HSV(float hue, float saturation, float value)
        {
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }
    }
}
