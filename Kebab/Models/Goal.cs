using Kebab.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kebab.Models
{
    class Goal
    {

        public TEAM Team { get; private set; }
        public Vector3 LeftPost { get; private set; }
        public Vector3 RightPost { get; private set; }
        public float Width { get; private set; }

        public Goal(TEAM team, Vector3 left, Vector3 right, float width)
        {
            Team = team;
            LeftPost = left;
            RightPost = right;
            Width = width;
        }

        public enum TEAM
        {
            BLUE = 0,
            ORANGE = 1
        }

        public Vector3 GetCenter2D()
        {
            return (LeftPost + RightPost) / 2f;
        }
    }
}
