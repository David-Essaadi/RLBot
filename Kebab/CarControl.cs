using Kebab.Models;
using RLBotDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab
{
    class CarControl
    {
        public static Controller GetControllerForDestination(Controller controller, Destination destination, BotState botState)
        {
            if(destination == null)
            {
                controller.Throttle = 1;
                return controller;
            }
            Vector3 destLoc = destination.Location;
            Vector3 destVelocity = destination.Velocity;
            Vector3 botLoc = botState.Location;
            Vector3 target = destination.Location + destination.Velocity;
            
            double botToTargetAngle = Math.Atan2(destLoc.Y - botLoc.Y, destLoc.X - botLoc.X);
            double botFrontToTargetAngle = botToTargetAngle - botState.Rotation.Yaw;
            // Correct the angle
            if (botFrontToTargetAngle < -Math.PI)
            {
                botFrontToTargetAngle += 2 * Math.PI;
            }
            if (botFrontToTargetAngle > Math.PI)
            {
                botFrontToTargetAngle -= 2 * Math.PI;
            }
            if (botFrontToTargetAngle > 0)
            {
                controller.Steer = 2 * (float)Math.PI;
            }
            else if (botFrontToTargetAngle < 0)
            {
                controller.Steer = -2 * (float)Math.PI;
            }
            else
            {
                controller.Steer = 0;
            }
            return controller;
        }
    }
}
