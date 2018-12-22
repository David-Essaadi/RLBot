using Kebab.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kebab.Models
{
    class Map
    {
        public List<Goal> Goals { get; private set; }

        public Map()
        {
            Goals = new List<Goal>();
            SetupDefaultGoals();
        }

        /// <summary>
        /// Returns the Goal object associated with the given team
        /// </summary>
        /// <param name="team">The Team of which we want to get the goal</param>
        /// <returns>The requested Goal object</returns>
        public Goal GetGoal(Goal.TEAM team)
        {
            return Goals.Where(el => el.Team == team).FirstOrDefault();
        }

        /// <summary>
        /// Adds the goal locations to Goal objects, and adds these to the List of goals
        /// </summary>
        private void SetupDefaultGoals()
        {
            Goal blueGoal = new Goal(Goal.TEAM.BLUE, new Vector3(-892.755f, -5120, 642.775f), new Vector3(892.755f, -5120, 642.775f), 1786);
            Goal orangeGoal = new Goal(Goal.TEAM.ORANGE, new Vector3(892.755f, 5120, 642.775f), new Vector3(-892.755f, 5120, 642.775f), 1786);
            Goals.Add(blueGoal);
            Goals.Add(orangeGoal);
        }
    }
}
