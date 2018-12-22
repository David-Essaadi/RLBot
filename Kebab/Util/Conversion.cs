using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Util
{
    class Conversion
    {
        public static Vector3 ToVector3(rlbot.flat.Vector3 vec)
        {
            return new Vector3(vec.X, vec.Y, vec.Z);
        }

        public static Rotation ToRotation(rlbot.flat.Rotator rotator)
        {
            return new Rotation(rotator.Yaw, rotator.Pitch, rotator.Roll);
        }
    }
}
