using Kebab.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Models
{
    class Destination
    {
        /// <summary>
        /// The Location of the desired destination
        /// </summary>
        public Vector3 Location { get; private set; }
        /// <summary>
        /// The minimum required directional velocity on impact
        /// </summary>
        public Vector3 Velocity { get; private set; }

        public Destination()
        {
            Location = new Vector3(0, 0, 0);
            Velocity = new Vector3(0, 0, 0);
        }

        public static Destination DecideDestination(Map map, GameState gameState, BotState botState, Goal.TEAM allyTeam, Goal.TEAM enemyTeam)
        {
            Destination destination = new Destination();
            destination = Shoot(map.GetGoal(allyTeam), map.GetGoal(enemyTeam), gameState, botState, enemyTeam);
            return destination;
        }

        public static Destination Shoot(Goal allyGoal, Goal enemyGoal, GameState gameState, BotState botState, Goal.TEAM enemyTeam)
        {
            //Get the location to hit on the ball
            Ball ball = gameState.Ball;
            Vector3 left = ball.GetRightFacingEnemyGoal(enemyTeam, allyGoal);
            Vector3 right = ball.GetLeftFacingEnemyGoal(enemyTeam, allyGoal);
            Vector3 location = (left + right) / 2f;
            //Get the angular velocity to hit the ball with
            Vector3 goalCenter = enemyGoal.GetCenter2D();
            Vector3 velocity = goalCenter - location;
            return new Destination()
            {
                Location = location,
                Velocity = velocity
            };
        }

        private static float Angle_2D(Vector3 target_location, Vector3 object_location)
        {
            Vector3 difference = target_location - object_location;
            return (float)Math.Atan2(difference.Y, difference.X);
        }
    }
}
