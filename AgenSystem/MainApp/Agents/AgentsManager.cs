using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainApp.Agents
{
    public static class AgentsManager
    {
        public static bool IsInitialized;
        public static int PositionSize;

        public static int Width {
            get {
                CheckWhetherInitalized();
                return AgentsArray.Length;
            }
        }
        public static int Height {
            get {
                CheckWhetherInitalized();
                return AgentsArray[0].Length;
            }
        }

        public static AgentBase[][] AgentsArray;

        public static IEnumerable<AgentBase> AAgents {
            get {
                CheckWhetherInitalized();

                return from AgentBase agent in AgentsArray
                       where agent != null && typeof(AgentB) == agent.GetType()
                       select agent;
            }
        }

        public static void Initialize(int width, int height, int cellSize, int agentsACount, int agentsBCount)
        {
            if (IsInitialized) throw new Exception("Already initialized!");

            PositionSize = cellSize;
            AgentsArray = new AgentBase[width][];
            for (var index = 0; index < AgentsArray.Length; index++)
                AgentsArray[index] = new AgentBase[height];

            CreateAgents(agentsACount, agentsBCount);
            
            IsInitialized = true;
        }

        private static void CheckWhetherInitalized()
        {
            if (!IsInitialized) throw new Exception("Agents manager not initialized!");
        }

        private static void CreateAgents(int agentsACount, int agentsBCount)
        {
            if(Width * Height / 2 < agentsACount + agentsBCount)
                throw new Exception("There is too many agents to fit desired space!");

            for (var i = 0; i < agentsACount; i++)
            {
                
            }
        }


    }
}
