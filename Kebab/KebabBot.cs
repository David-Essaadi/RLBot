using Kebab.Models;
using Kebab.Util;
using rlbot.flat;
using RLBotDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab
{
    internal class KebabBot : Bot
    {
        private Controller controller;
        private readonly Map map;
        private readonly Goal.TEAM allyTeam;
        private readonly Goal.TEAM enemyTeam;
        private readonly Car car;

        // Use the base constructor 
        public KebabBot(string botName, int botTeam, int botIndex) : base(botName, botTeam, botIndex)
        {
            controller = new Controller();
            map = new Map();
            allyTeam = (Goal.TEAM)botTeam;
            enemyTeam = allyTeam == Goal.TEAM.BLUE ? Goal.TEAM.ORANGE : Goal.TEAM.BLUE;
            car = new Octane();
        }

        /// <summary>
        /// Gets called every game tick. Returns a controller state
        /// </summary>
        /// <param name="gameTickPacket"></param>
        /// <returns>The desired controller inputs to be pressed</returns>
        public override Controller GetOutput(GameTickPacket gameTickPacket)
        {
            try
            {
                GameState gameState = GameState.ParseFromPacket(gameTickPacket);
                Ball ball = Ball.ParseFromGamePacket(gameTickPacket);
                BotState botState = BotState.ParseFromGameState(gameState, index);
                Destination destination = Destination.DecideDestination(map, gameState, botState, allyTeam, enemyTeam);
                controller = CarControl.GetControllerForDestination(controller, destination, botState);
                controller.Throttle = 1f;
                Debug.DrawAll(Renderer, botState, car, ball, map, allyTeam, enemyTeam);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return controller;
        }
    }
}
