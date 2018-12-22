using Kebab.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Models
{
    class Ball
    {
        public const float Radius = 92.75f;
        public Vector3 Location { get; private set; }
        public Rotation Rotation { get; private set; }
        public Vector3 Velocity { get; private set; }
        public Vector3 AngularVelocity { get; private set; }

        public Ball()
        {

        }

        public static Ball ParseFromGamePacket(rlbot.flat.GameTickPacket packet)
        {
            rlbot.flat.BallInfo info = packet.Ball.GetValueOrDefault();
            rlbot.flat.Physics physics = info.Physics.Value;
            return new Ball()
            {
                Location = Conversion.ToVector3(physics.Location.GetValueOrDefault()),
                Rotation = Conversion.ToRotation(physics.Rotation.GetValueOrDefault()),
                Velocity = Conversion.ToVector3(physics.Velocity.GetValueOrDefault()),
                AngularVelocity = Conversion.ToVector3(physics.AngularVelocity.GetValueOrDefault()),
            };
        }

        public Vector3 GetLeftFacingEnemyGoal(Goal.TEAM ourTeam, Goal goal)
        {
            Vector3 left = new Vector3()
            {
                X = goal.LeftPost.X,
                Y = goal.LeftPost.Y
            };
            Vector3 pL = (left - Location) * -1;
            pL = Vector3.Normalize(pL);
            pL *= Ball.Radius;
            return pL + Location;
        }

        public Vector3 GetRightFacingEnemyGoal(Goal.TEAM ourTeam, Goal goal)
        {
            Vector3 right = new Vector3()
            {
                X = goal.RightPost.X,
                Y = goal.RightPost.Y
            };
            Vector3 pR = (right - Location) * -1;
            pR = Vector3.Normalize(pR);
            pR *= Ball.Radius;
            return pR + Location;
        }

        public Vector3 GetLeftFacingAllyGoal(Goal.TEAM enemyTeam, Goal goal, Vector3 Location)
        {
            Vector3 frontLeft = new Vector3(Radius, 0, 0);
            return Rotation.Rotate2D((float)(Math.PI / 4 + Math.PI * (int)enemyTeam + GetGoalAngle(goal)), frontLeft) + Location;
        }

        public Vector3 GetRightFacingAllyGoal(Goal.TEAM enemyTeam, Goal goal, Vector3 Location)
        {
            Vector3 frontLeft = new Vector3(Radius, 0, 0);
            return Rotation.Rotate2D((float)(3 * Math.PI / 4 + Math.PI * (int)enemyTeam + GetGoalAngle(goal)), frontLeft) + Location;
        }

        public float GetGoalAngle(Goal goal)
        {
            float dXL = goal.LeftPost.X - Location.X;
            float dXR = goal.RightPost.X - Location.X;
            float dY = goal.LeftPost.Y - Location.Y;
            if (dXR > dXL)
            {
                return (float)(Math.Atan2(dXR, dY) - Math.Atan2(dXL, dY));
            }
            return (float)(Math.Atan2(dXL, dY) + Math.Atan2(dXR, dY));
        }
    }
}
