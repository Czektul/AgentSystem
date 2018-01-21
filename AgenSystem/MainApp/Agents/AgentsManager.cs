using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainApp.Helpers;
using static MainApp.Helpers.Enums;

namespace MainApp.Agents
{
    public static class AgentsManager
    {
        public static bool IsInitialized;
        public static int CellSize;

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

        public static Color AgentAColor { get; set; } = Color.Red;
        public static Color AgentBColor { get; set; } = Color.Green;

        public static Agent[][] AgentsArray;

        public static ref Agent Slot(Position pos)
        {
            CheckWhetherInitalized();
            return ref AgentsArray[pos.X][pos.Y];
        }

        public static IEnumerable<Agent> GetSlotsOfType(SlotState occupyType)
        {
            CheckWhetherInitalized();
            if (occupyType == SlotState.Empty)
                return from Agent agent in AgentsArray
                       where agent == null
                       select agent;

            return from Agent agent in AgentsArray
                   where agent.Type == occupyType
                   select agent;

        }
        
        public static SlotState GetSlotState(Position pos)
        {
            CheckWhetherInitalized();

            var slot = AgentsArray[pos.X][pos.Y];

            if (slot == null) return SlotState.Empty;

            return slot.Type;
        }
        
        public static void Initialize(ref Panel parent, int width, int height, int cellSize, int agentsACount,
            int agentsBCount)
        {
            if (IsInitialized) throw new Exception("Already initialized!");

            CellSize = cellSize;
            AgentsArray = new Agent[width][];
            for (var index = 0; index < AgentsArray.Length; index++)
                AgentsArray[index] = new Agent[height];

            IsInitialized = true;

            parent.Width = width * cellSize;
            parent.Height = height * cellSize;

            CreateAgents(parent, agentsACount, agentsBCount);
        }

        private static void CheckWhetherInitalized()
        {
            if (!IsInitialized)
                throw new Exception("Agents manager not initialized!");
        }

        private static void CreateAgents(Panel parent, int agentsACount, int agentsBCount, int seed = 0)
        {
            if (Width * Height / 2 < agentsACount + agentsBCount)
                throw new Exception("There is too many agents to fit desired space!");

            Random rng = new Random(seed);
            FillWithAgents(parent, SlotState.AgentA, agentsACount, rng);
            FillWithAgents(parent, SlotState.AgentB, agentsBCount, rng);

        }

        private static void FillWithAgents(Control parent, SlotState kind, int agentsCount, Random rng)
        {
            for (var i = 0; i < agentsCount; i++)
            {
                Position? pos = null;
                while (pos == null || Slot(pos.Value) != null)
                    pos = new Position
                    {
                        X = rng.Next(Height - 1),
                        Y = rng.Next(Width - 1)
                    };
                switch (kind)
                {
                    case SlotState.AgentA:
                        Slot(pos.Value) = new AgentA(parent, pos.Value);
                        break;
                    case SlotState.AgentB:
                        Slot(pos.Value) = new AgentB(parent, pos.Value);
                        break;
                }
            }
        }
    }
}

