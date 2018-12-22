using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Kebab.Util
{
    class Rotation
    {
        public float Yaw { get; private set; }
        public float Pitch { get; private set; }
        public float Roll { get; private set; }

        public Rotation(float yaw, float pitch, float roll)
        {
            Yaw = yaw;
            Pitch = pitch;
            Roll = roll;
        }

        public static Vector3 Rotate2D(float angle, Vector3 vec)
        {
            Vector3 ret = new Vector3()
            {
                X = (float)(vec.X * Math.Cos(angle) - -vec.Y * Math.Sin(angle)),
                Y = (float)(vec.X * Math.Sin(angle) + Math.Cos(angle)),
                Z = 0
            };
            return ret;
        }
    }
}
