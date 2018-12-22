using rlbot.flat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Models
{
    class GameState
    {
        public Ball Ball { get; private set; }
        public List<BoostPadState> BoostPadStates { get; private set; }
        public List<PlayerInfo> Players { get; private set; }

        /// <summary>
        /// Returns the player info associated with the given index
        /// </summary>
        /// <param name="index">The index of the player</param>
        /// <returns>A PlayerInfo object containing information about the player</returns>
        public PlayerInfo GetPlayerInfo(int index)
        {
            return Players[index];
        }

        /// <summary>
        /// Parses the given GameTickPacket into the info required for our bot
        /// </summary>
        /// <param name="packet">The next tick packet</param>
        /// <returns>A GameState object containing the parsed values</returns>
        public static GameState ParseFromPacket(rlbot.flat.GameTickPacket packet)
        {
            GameState state = new GameState();
            // Ball information
            state.Ball = Ball.ParseFromGamePacket(packet);
            // Boost pads
            if (state.BoostPadStates == null)
            {
                state.BoostPadStates = new List<BoostPadState>(packet.BoostPadStatesLength);
            }
            for (int i = 0; i < packet.BoostPadStatesLength; i++)
            {
                state.BoostPadStates.Add(packet.BoostPadStates(i).GetValueOrDefault());
            }
            // Players
            if (state.Players == null)
            {
                state.Players = new List<PlayerInfo>(packet.PlayersLength);
            }
            for (int i = 0; i < packet.PlayersLength; i++)
            {
                state.Players.Add(packet.Players(i).GetValueOrDefault());
            }
            return state;
        }
    }
}
