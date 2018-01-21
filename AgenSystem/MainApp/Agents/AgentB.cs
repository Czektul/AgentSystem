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

        protected override void ProcessMovement()
        {

        }
    }
}
