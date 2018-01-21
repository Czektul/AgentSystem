using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainApp.Helpers;

namespace MainApp.Agents
{
    public class AgentB : Agent
    {
        public AgentB(Control parent, Position initPosition)
            : base(parent, initPosition, Enums.SlotState.AgentB)
        {

        }

        public override void ProcessMovement()
        {
            var direction = AgentsManager.RNG.Next(4);
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
    }
}
