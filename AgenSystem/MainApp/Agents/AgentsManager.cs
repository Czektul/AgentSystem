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
        public static Random RNG;
        public static Panel AgentsParentPanel;
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

        public static List<Agent> GetSlotsOfType(SlotState occupyType)
        {
            CheckWhetherInitalized();
            var agents = new List<Agent>();
            foreach (Agent[] t in AgentsArray)
            {
                agents.AddRange(t.Where(
                    currentSlot => occupyType == SlotState.Empty && currentSlot == null 
                    || currentSlot != null && occupyType == currentSlot.Type));
            }
            return agents;
        }

        public static SlotState GetSlotState(Position pos)
        {
            CheckWhetherInitalized();
            Agent slot;
            try
            {
                slot = Slot(pos);
            }
            catch (IndexOutOfRangeException)
            {
                return SlotState.OutOfBounds;
            }

            return slot?.Type ?? SlotState.Empty;
        }

        public static bool IsSlotInside(Position pos)
        {
            return !(pos.X < 0 || pos.X >= Width || pos.Y < 0 || pos.Y >= Width);
        }

        public static void Initialize(ref Panel parent, int width, int height, int cellSize, int agentsACount,
            int agentsBCount, int seed = 0)
        {
            if (IsInitialized) throw new Exception("Already initialized!");

            AgentsParentPanel = parent;

            CellSize = cellSize;
            AgentsArray = new Agent[width][];
            for (var index = 0; index < AgentsArray.Length; index++)
                AgentsArray[index] = new Agent[height];

            RNG = new Random(seed);

            parent.Width = width * cellSize;
            parent.Height = height * cellSize;
            
            IsInitialized = true;

            CreateAgents(AgentsParentPanel, agentsACount, agentsBCount);
        }
        
        public static void UpdateAllAgents()
        {
            if(!IsInitialized) return;

            Console.WriteLine("~~~~~~~~~~");
            Console.WriteLine("Updating all agents");
            foreach (var agent in GetSlotsOfType(SlotState.AgentA).ToList())
                agent.ProcessMovement();
            foreach (var agent in GetSlotsOfType(SlotState.AgentB).ToList())
                agent.ProcessMovement();

            Console.WriteLine("Redrawing all agents");
            foreach (var agent in GetSlotsOfType(SlotState.AgentA).ToList())
                agent.ReDraw();
            foreach (var agent in GetSlotsOfType(SlotState.AgentB).ToList())
                agent.ReDraw();

            AgentsParentPanel.Update();
        }

        private static void CheckWhetherInitalized()
        {
            if (!IsInitialized)
                throw new Exception("Agents manager not initialized!");
        }

        private static void CreateAgents(Panel parent, int agentsACount, int agentsBCount)
        {
            if (Width * Height / 2 < agentsACount + agentsBCount)
                throw new Exception("There is too many agents to fit desired space!");

            FillWithAgents(parent, SlotState.AgentA, agentsACount);
            FillWithAgents(parent, SlotState.AgentB, agentsBCount);
        }

        private static void FillWithAgents(Control parent, SlotState kind, int agentsCount)
        {
            for (var i = 0; i < agentsCount; i++)
            {
                Position? pos = null;
                while (pos == null || Slot(pos.Value) != null)
                    pos = new Position
                    {
                        X = RNG.Next(Width - 1),
                        Y = RNG.Next(Height - 1)
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