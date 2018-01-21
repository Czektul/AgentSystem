using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainApp.Helpers;
using static MainApp.Agents.AgentsManager;
using static MainApp.Helpers.Enums;

namespace MainApp.Agents
{
    public class AgentA : Agent
    {
        public List<AgentA> Memory_A;
        public List<AgentB> Memory_B;
        public List<Agent> Message;
        public int rangeOfView = 5;

        public AgentA(Control parent, Position initPosition)
            : base(parent, initPosition, Enums.SlotState.AgentA)
        {
            Memory_A = new List<AgentA>();
            Memory_B = new List<AgentB>();
        }

        public override void ProcessMovement()
        {
            SearchB();
            int direction = AgentsManager.RNG.Next(4);

            if (CheckDirection(direction))
            {
                switch (direction)
                {
                    case 0:
                        MoveAgent(0, 1);
                        break;
                    case 1:
                        MoveAgent(1, 0);
                        break;
                    case 2:
                        MoveAgent(0, -1);
                        break;
                    case 3:
                        MoveAgent(-1, 0);
                        break;
                }
            }
            else ProcessMovement();
        }

        public void SearchB()
        {
            Memory_B = new List<AgentB>();
            Position pos = Position;
            for (int i = rangeOfView * 2 + 1; i > 0; i--)
            {
                pos.X = Position.X + i;
                if (GetSlotState(pos) == SlotState.AgentB)
                {
                    Memory_B.Add((AgentB)Slot(pos));
                }
            }
            pos = Position;
            for (int i = rangeOfView * 2 + 1; i > 0; i--)
            {
                pos.Y = Position.Y + i;
                if (GetSlotState(pos) == SlotState.AgentB)
                {
                    Memory_B.Add((AgentB)Slot(pos));
                }
            }
            if (Memory_B.Count != 0)
            {
                SearchA();
                Broadcast();
            }

        }
        public void SearchA()
        {
            Memory_A = new List<AgentA>();
            Position pos = Position;
            pos.X = Position.X + 1;
            if (GetSlotState(pos) == SlotState.AgentA)
            {
                Memory_A.Add((AgentA)Slot(pos));
            }

            pos.X = Position.X - 1;
            if (GetSlotState(pos) == SlotState.AgentA)
            {
                Memory_A.Add((AgentA)Slot(pos));
            }
            pos.X = Position.X;
            pos.Y = Position.Y + 1;
            if (GetSlotState(pos) == SlotState.AgentA)
            {
                Memory_A.Add((AgentA)Slot(pos));
            }
            pos.Y = Position.Y - 1;
            if (GetSlotState(pos) == SlotState.AgentA)
            {
                Memory_A.Add((AgentA)Slot(pos));
            }

        }
        public void Broadcast()
        {
            foreach(AgentA agent in Memory_A)
            {
                agent.Memory_B = Memory_B;
            }
        }
        public bool CheckDirection(int moveType)
        {
            Position pos = Position;
            foreach(AgentB agent in Memory_B)
            {
                if (moveType == 0) //y++
                {
                    for (int i = 0; i < rangeOfView; i++)
                    {
                        try
                        {
                            if ((pos.X == agent.Position.X) && (pos.Y + i == agent.Position.Y))
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }

                }
                else if (moveType == 1) //x++
                {
                    for (int i = 0; i < rangeOfView; i++)
                    {
                        try
                        {
                            if ((pos.X + i == agent.Position.X) && (pos.Y == agent.Position.Y))
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }

                }
                else if(moveType == 2) //y--
                {
                    for (int i = 0; i < rangeOfView; i++)
                    {
                        try
                        {
                            if ((pos.X == agent.Position.X) && (pos.Y - i == agent.Position.Y))
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }

                }
                else if(moveType == 3) //x--
                {
                    for (int i = 0; i < rangeOfView; i++)
                    {
                        try
                        {
                            if ((pos.X - i == agent.Position.X) && (pos.Y == agent.Position.Y))
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }

                }
            }
            return true;
        }

    }
    
}
