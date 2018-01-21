using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainApp.Helpers;
using static MainApp.Agents.AgentsManager;

namespace MainApp.Agents
{
    public class AgentA : Agent
    {
        public AgentA(Control parent, Position initPosition)
            : base(parent, initPosition, Enums.SlotState.AgentA)
        {

        }

        protected override void ProcessMovement()
        {

        }
    }
}
