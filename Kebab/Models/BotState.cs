using Kebab.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Models
{
    class BotState
    {
        public Vector3 Location { get; private set; }
        public Rotation Rotation { get; private set; }

        public BotState()
        {

        }

        public static BotState ParseFromGameState(GameState gameState, int botIndex)
        {
            BotState botState = new BotState();
            rlbot.flat.PlayerInfo info = gameState.GetPlayerInfo(botIndex);
            botState.Location = Conversion.ToVector3(info.Physics.GetValueOrDefault().Location.GetValueOrDefault());
            botState.Rotation = Conversion.ToRotation(info.Physics.GetValueOrDefault().Rotation.GetValueOrDefault());
            return botState;
        }
    }
}
