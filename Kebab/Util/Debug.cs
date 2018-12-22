using Kebab.Models;
using RLBotDotNet.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kebab.Util
{
    class Debug
    {
        public static void DrawAll(Renderer renderer, BotState botState, Car car, Ball ball, Map map, Goal.TEAM allyTeam, Goal.TEAM enemyTeam)
        {
            Debug.DrawCarCenter(renderer, botState.Location);
            Debug.DrawCarOutline(renderer, car, botState);
            Debug.DrawBallFrontFacingEnemyGoal(renderer, ball, allyTeam, map.GetGoal(enemyTeam), botState.Location);
            Debug.DrawBallFrontFacingOurGoal(renderer, ball, enemyTeam, map.GetGoal(allyTeam), botState.Location);
        }

        public static void DrawCarCenter(Renderer renderer, Vector3 location)
        {
            renderer.DrawRectangle3D(Color.FromRgb(255, 255, 0), location, 10, 10, true);
        }

        public static void DrawCarOutline(Renderer renderer, Car car, BotState botState)
        {
            Vector3 frontLeft = car.GetFrontLeft(botState.Location, botState.Rotation);
            Vector3 frontRight = car.GetFrontRight(botState.Location, botState.Rotation);
            Vector3 backLeft = car.GetBackLeft(botState.Location, botState.Rotation);
            Vector3 backRight = car.GetBackRight(botState.Location, botState.Rotation);
            //Front side
            renderer.DrawLine3D(Color.FromRgb(255, 255, 0), frontLeft, frontRight);
            //Left side
            renderer.DrawLine3D(Color.FromRgb(255, 255, 0), frontLeft, backLeft);
            //Right side
            renderer.DrawLine3D(Color.FromRgb(255, 255, 0), frontRight, backRight);
            //Back side
            renderer.DrawLine3D(Color.FromRgb(255, 255, 0), backLeft, backRight);
        }

        public static void DrawBallFrontFacingEnemyGoal(Renderer renderer, Ball ball, Goal.TEAM ourTeam, Goal goal, Vector3 location)
        {
            Vector3 frontLeft = ball.GetLeftFacingEnemyGoal(ourTeam, goal);
            Vector3 frontRight = ball.GetRightFacingEnemyGoal(ourTeam, goal);
            renderer.DrawLine3D(Color.FromRgb(255, 0, 0), frontLeft, frontRight);
        }

        public static void DrawBallFrontFacingOurGoal(Renderer renderer, Ball ball, Goal.TEAM enemyTeam, Goal goal, Vector3 location)
        {
            Vector3 frontLeft = ball.GetLeftFacingAllyGoal(enemyTeam, goal, location);
            Vector3 frontRight = ball.GetRightFacingAllyGoal(enemyTeam, goal, location);
            //renderer.DrawLine3D(Color.FromRgb(0, 0, 255), frontLeft, frontRight);
        }
    }
}
