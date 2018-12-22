using Kebab.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Models
{
    abstract class Car
    {
        public float Length { get; protected set; }
        public float Width { get; protected set; }

        /// /// <summary>
        /// Returns the leftmost part of the front of the car
        /// </summary>
        /// <returns>A Vec3 with the position of the part</returns>
        public Vector3 GetFrontLeft(Vector3 center, Rotation rotation)
        {
            Vector3 front = new Vector3(center.X, center.Y, center.Z);
            front.X += (float)(Length / 2 * Math.Cos(rotation.Yaw) - -Width / 2 * Math.Sin(rotation.Yaw));
            front.Y += (float)(Length / 2 * Math.Sin(rotation.Yaw) - Width / 2 * Math.Cos(rotation.Yaw));
            return front;
        }

        /// <summary>
        /// Returns the rightmost part of the front of the car
        /// </summary>
        /// <returns>A Vec3 with the position of the part</returns>
        public Vector3 GetFrontRight(Vector3 center, Rotation rotation)
        {
            Vector3 front = new Vector3(center.X, center.Y, center.Z);
            front.X += (float)(Length / 2 * Math.Cos(rotation.Yaw) - Width / 2 * Math.Sin(rotation.Yaw));
            front.Y += (float)(Length / 2 * Math.Sin(rotation.Yaw) + Width / 2 * Math.Cos(rotation.Yaw));
            return front;
        }

        public Vector3 GetBackLeft(Vector3 center, Rotation rotation)
        {
            Vector3 front = new Vector3(center.X, center.Y, center.Z);
            front.X += (float)(-Length / 2 * Math.Cos(rotation.Yaw) - -Width / 2 * Math.Sin(rotation.Yaw));
            front.Y += (float)(-Length / 2 * Math.Sin(rotation.Yaw) - Width / 2 * Math.Cos(rotation.Yaw));
            return front;
        }

        public Vector3 GetBackRight(Vector3 center, Rotation rotation)
        {
            Vector3 front = new Vector3(center.X, center.Y, center.Z);
            front.X += (float)(-Length / 2 * Math.Cos(rotation.Yaw) - Width / 2 * Math.Sin(rotation.Yaw));
            front.Y += (float)(-Length / 2 * Math.Sin(rotation.Yaw) + Width / 2 * Math.Cos(rotation.Yaw));
            return front;
        }
    }
}
